using Library.NET.Helpers;

using WinSCP;

namespace Library.NET.SFTP.WinSCP;
public static class Personal
{
    private static readonly string _localPath = Path.Combine(@"\\jcfs", "Personal");
    private static readonly string _dfsPath = Path.Combine(@"\\crimsonorion.com", "dfs", "Personal");
    public static string LocalDirectoryPath => Directory.Exists(_dfsPath) ? _dfsPath : _localPath;
    public static string SessionLogPath => Path.Combine(LocalDirectoryPath, "BackupLog.txt");
    public static string MDM_DirectoryPath => Path.Combine(@"\\jcmdm", "Personal");
    public static string SessionLogPathPerm => Path.Combine(LocalDirectoryPath, "Logs", $"BackupArchive_{DateTime.Now:yyyyMMdd_HHmmss}.txt");
    public static string RemoteDirectoryPath => Path.Combine("delivery_files").WindowsToLinuxPath();

    public static SessionOptions SessionOptions => new()
    {
        Protocol = Protocol.Sftp,
        HostName = "personal.crimsonorion.com",
        UserName = "myUsername",
        Password = "myPassword",
        SshHostKeyFingerprint = "ssh-rsa 2048 ab:cd:ef:00:00:00:00:00:00:00:00:00:00:00:00:00"
    };

    public static TransferOptions TransferOptions
    {
        get
        {
            var transferOptions = new TransferOptions()
            {
                TransferMode = TransferMode.Binary,
                FileMask = ">today|*/Reports/*; */Events/*"
            };
            transferOptions.ResumeSupport.State = TransferResumeSupportState.Off;

            return transferOptions;
        }
    }
}