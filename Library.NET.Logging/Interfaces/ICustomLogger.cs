
namespace Library.NET.Logging;

public interface ICustomLogger
{
    FileInfo LogFileInfo { get; set; }
    LogLevel LogLevel { get; set; }
    bool OutputToConsole { get; set; }
}