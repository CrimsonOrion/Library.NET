using Library.NET.Logging;
using Library.NET.SFTP.WinSCP;

using WinSCP;

namespace Library.NET.SFTP;
public interface IWinSCP
{
    IEnumerable<string> GetFiles();
    IEnumerable<string> RemoveFiles(string removalFilePathAndMask);
    void Setup(Protocol protocol, string hostname, string username, string password, string sshHostKeyFingerprint, string sessionLogPath, string remoteDirectoryPath, string localDirectoryPath, string transferOptionFilemask, bool removeFiles = false);
    void Setup(TransferSessionOption transferSessionOption, ICustomLogger customLogger);
}