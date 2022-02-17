namespace Library.NET.Logging;
public class CustomLogger : ICustomLogger
{
    public FileInfo LogFileInfo { get; set; }
    public bool OutputToConsole { get; set; }
    public LogLevel LogLevel { get; set; }

    public CustomLogger(FileInfo logFileInfo, bool outputToConsole, LogLevel logLevel)
    {
        LogFileInfo = logFileInfo;
        OutputToConsole = outputToConsole;
        LogLevel = logLevel;
    }
}

public enum LogLevel
{
    Debug,
    Information,
    Warning,
    Trace,
    Error,
    Critical
}