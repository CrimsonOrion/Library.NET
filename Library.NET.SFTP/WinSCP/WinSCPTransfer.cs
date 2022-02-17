using Library.NET.Logging;

using WinSCP;

namespace Library.NET.SFTP.WinSCP;
public class WinSCPTransfer : IWinSCP
{
    private string _sessionLogPath;
    private string _remoteDirectoryPath;
    private string _localDirectoryPath;
    private bool _removeFiles;
    private int _retryWaitTimeMinutes;
    private int _maxRetryAttempts;
    private TransferSessionOption _transferSessionOption;
    private SessionOptions _sessionOptions;
    private TransferOptions _transferOptions;
    private ICustomLogger _logger;

    public WinSCPTransfer() { }

    public void Setup(TransferSessionOption transferSessionOption, ICustomLogger customLogger)
    {
        _logger = customLogger;
        _transferSessionOption = transferSessionOption;

        if (_transferSessionOption == TransferSessionOption.Public)
        {
            _sessionOptions = Public.SessionOptions;
            _transferOptions = Public.TransferOptions;
            _sessionLogPath = Public.SessionLogPath;
            _remoteDirectoryPath = Public.RemoteDirectoryPath;
            _localDirectoryPath = Public.LocalDirectoryPath;
            _removeFiles = false;
            _retryWaitTimeMinutes = 2;
            _maxRetryAttempts = 30;
        }
        else if (_transferSessionOption == TransferSessionOption.Personal)
        {
            _sessionOptions = Personal.SessionOptions;
            _transferOptions = Personal.TransferOptions;
            _sessionLogPath = Personal.SessionLogPath;
            _remoteDirectoryPath = Personal.RemoteDirectoryPath;
            _localDirectoryPath = Personal.LocalDirectoryPath;
            _removeFiles = false;
            _retryWaitTimeMinutes = 5;
            _maxRetryAttempts = 5;
        }
    }

    public void Setup(Protocol protocol, string hostname, string username, string password, string sshHostKeyFingerprint, string sessionLogPath, string remoteDirectoryPath, string localDirectoryPath, string transferOptionFilemask, bool removeFiles = false)
    {
        _logger = new CustomLogger(new(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "WinSCPtransfer.log")), true, LogLevel.Information);
        _sessionOptions = new SessionOptions()
        {
            Protocol = protocol,
            HostName = hostname,
            UserName = username,
            Password = password,
            SshHostKeyFingerprint = sshHostKeyFingerprint
        };

        _transferOptions = new TransferOptions()
        {
            TransferMode = TransferMode.Binary,
            FileMask = transferOptionFilemask
        };
        _transferOptions.ResumeSupport.State = TransferResumeSupportState.Off;
        _sessionLogPath = sessionLogPath;
        _remoteDirectoryPath = remoteDirectoryPath;
        _localDirectoryPath = localDirectoryPath;
        _removeFiles = removeFiles;
        _retryWaitTimeMinutes = 10;
        _maxRetryAttempts = 1;
    }

    public IEnumerable<string> GetFiles()
    {
        var hasAllFiles = false;
        IEnumerable<string> fileList = new List<string>();
        var retries = 0;

        // Do this until it has the files or retry attempts are less than or equal to max retry attempts
        while (!hasAllFiles && retries <= _maxRetryAttempts)
        {
            try
            {
                using var session = new Session
                {
                    SessionLogPath = _sessionLogPath
                };

                session.Open(_sessionOptions);

                // Get files
                _logger.LogInformation("Retrieving files...");
                var transferResult = session.GetFiles(_remoteDirectoryPath, _localDirectoryPath, _removeFiles, _transferOptions);
                transferResult.Check();
                _logger.LogInformation("Files retrieved. Verifying they all transferred...");

                fileList = transferResult.Transfers.Select(_ => _.FileName);

                hasAllFiles = CheckForFiles(fileList);
            }
            catch (Exception ex) // If there's a problem, report it and return false so it will run a second time
            {
                _logger.LogError(ex, $"Error transferring files. Will try again in {_retryWaitTimeMinutes} minutes.");
            }

            if (hasAllFiles)
            {
                _logger.LogInformation("File transfer complete.");
            }
            else if (retries == _maxRetryAttempts)
            {
                _logger.LogWarning(new Exception("Not all files transferred. Out of retry attempts."), $"Not all the files transferred in {retries} attempts.");
                retries++;
            }
            else
            {
                // If the files aren't transferred, return false and wait _retryWaitTimeMinutes minutes to try again.
                _logger.LogWarning(new Exception("Not all files transferred."), $"Not all the files transferred. Trying again in {_retryWaitTimeMinutes} minutes.");
                Thread.Sleep(_retryWaitTimeMinutes * 60 * 1000);
                retries++;
            }
        }

        return fileList;
    }

    public IEnumerable<string> RemoveFiles(string removalFilePathAndMask)
    {
        IEnumerable<string> fileList = new List<string>();
        try
        {
            using var session = new Session
            {
                SessionLogPath = _sessionLogPath
            };

            session.Open(_sessionOptions);

            // Remove files
            _logger.LogInformation("Removing files...");
            var removalResult = session.RemoveFiles(removalFilePathAndMask);

            removalResult.Check();
            _logger.LogInformation("Files removed. The following files were removed:");

            fileList = removalResult.Removals.Select(_ => _.FileName);
            foreach (var file in fileList)
            {
                _logger.LogInformation(file);
            }
        }
        catch (Exception ex) // If there's a problem, report it and return false so it will run a second time
        {
            _logger.LogError(ex, "Error removing files.");
        }

        return fileList;
    }

    private bool CheckForFiles(IEnumerable<string> files)
    {
        if (_transferSessionOption == TransferSessionOption.Personal)
        {
            var lifeFile = "LifeFile.txt";

            var hasLifeFile = false;

            foreach (var file in files)
            {
                var comp = StringComparison.OrdinalIgnoreCase;
                if (file.Contains(lifeFile, comp))
                {
                    hasLifeFile = true;
                }
                _logger.LogInformation($"{file} transferred.");
            }

            return hasLifeFile;
        }
        else if (_transferSessionOption == TransferSessionOption.Public)
        {
            var publicAlarmFile = $"PublicAlarmFile_{DateTime.Now:yyyyMMddHH}";

            var hasAlarmFile = false;

            foreach (var file in files)
            {
                var comp = StringComparison.OrdinalIgnoreCase;
                if (file.Contains(publicAlarmFile, comp))
                {
                    hasAlarmFile = true;
                }
                _logger.LogInformation($"{file} transferred.");
            }

            return hasAlarmFile;
        }
        else
        {
            foreach (var file in files)
            {
                _logger.LogInformation($"{file} transferred.");
            }
            return true;
        }
    }
}