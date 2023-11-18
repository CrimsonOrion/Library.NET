using System.Diagnostics;

namespace Library.NET.Logging;

/// <summary>
/// Custom logger that sends messages of various levels to a log file and/or console
/// </summary>
public class CustomLogger : ICustomLogger
{
    public FileInfo? LogFileInfo { get; set; }
    public bool OutputToConsole { get; set; } = true;
    public LogLevel LogLevel { get; set; } = LogLevel.Debug;

    /// <summary>
    /// Custom logger that sends messages of various levels to a log file and, if desired, the console
    /// </summary>
    /// <param name="logFileInfo"><see cref="FileInfo"/> for the log file</param>
    /// <param name="outputToConsole">Sets if you want log data to output to the console</param>
    /// <param name="logLevel">Set the <see cref="Logging.LogLevel"/> to filter the information that gets passed to the logger</param>
    public CustomLogger(FileInfo logFileInfo, bool outputToConsole, LogLevel logLevel)
    {
        LogFileInfo = logFileInfo;
        OutputToConsole = outputToConsole;
        LogLevel = logLevel;
    }

    /// <summary>
    /// Custom logger that sends messages to the console
    /// </summary>
    /// <param name="logLevel">Set the <see cref="Logging.LogLevel"/> to filter the information that gets passed to the logger</param>
    public CustomLogger(LogLevel logLevel) => LogLevel = logLevel;

    /// <summary>
    /// Custom logger that sends messages to the console with <see cref="Logging.LogLevel.Debug"/> and higher
    /// </summary>
    public CustomLogger() { }

    public void LogDebug(string message)
    {
        if (LogLevel > LogLevel.Debug)
        {
            return;
        }

        var line = $"[Debug] <{DateTime.Now.ToShortDateString()} {DateTime.Now.ToLongTimeString()}> : {message}";

        Debug.WriteLine(line);

        if (OutputToConsole)
        {
            Console.WriteLine(line); // Don't change the color.
        }
    }

    public void LogInformation(string message)
    {
        if (LogLevel > LogLevel.Information)
        {
            return;
        }

        var line = $"[Information] <{DateTime.Now.ToShortDateString()} {DateTime.Now.ToLongTimeString()}> : {message}";

        if (LogFileInfo != null)
        {
            File.AppendAllText(LogFileInfo.FullName, line + $"\r\n");
        }

        if (OutputToConsole)
        {
            ConsoleColor defaultColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(line);
            Console.ForegroundColor = defaultColor;
        }
    }

    public void LogWarning(Exception exception, string? message)
    {
        if (LogLevel > LogLevel.Warning)
        {
            return;
        }

        var exceptionMessage = $"Exception Message:{exception.Message}";
        var line = string.IsNullOrEmpty(message)
            ? $"[Warning] <{DateTime.Now.ToShortDateString()} {DateTime.Now.ToLongTimeString()}> : {exceptionMessage}"
            : $"[Warning] <{DateTime.Now.ToShortDateString()} {DateTime.Now.ToLongTimeString()}> : {message}\r\n\t{exceptionMessage}";

        if (LogFileInfo != null)
        {
            File.AppendAllText(LogFileInfo.FullName, line + $"\r\n");
        }

        if (OutputToConsole)
        {
            ConsoleColor defaultColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(line);
            Console.ForegroundColor = defaultColor;
        }
    }

    public void LogTrace(Exception exception, string? message)
    {
        if (LogLevel > LogLevel.Trace)
        {
            return;
        }

        var exceptionMessage = $"Exception Message:{exception.Message}";
        var innerException = $"Inner Message:{exception.InnerException}";
        var stackTrace = $"Stack Trace:{exception.StackTrace}";
        var line = string.IsNullOrEmpty(message)
            ? $"[Error] <{DateTime.Now.ToShortDateString()} {DateTime.Now.ToLongTimeString()}> : {exceptionMessage}\r\n\t{innerException}\r\n\t{stackTrace}"
            : $"[Error] <{DateTime.Now.ToShortDateString()} {DateTime.Now.ToLongTimeString()}> : {message}\r\n\t{exceptionMessage}\r\n\t{innerException}\r\n\t{stackTrace}";

        if (LogFileInfo != null)
        {
            File.AppendAllText(LogFileInfo.FullName, line + $"\r\n");
        }

        if (OutputToConsole)
        {
            ConsoleColor defaultColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(line);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(stackTrace);
            Console.ForegroundColor = defaultColor;
        }
    }

    public void LogError(Exception exception, string? message)
    {
        if (LogLevel > LogLevel.Error)
        {
            return;
        }

        var exceptionMessage = $"Exception Message:{exception.Message}";
        var innerException = $"Inner Message:{exception.InnerException}";
        var stackTrace = $"Stack Trace:{exception.StackTrace}";
        var line = string.IsNullOrEmpty(message)
            ? $"[Error] <{DateTime.Now.ToShortDateString()} {DateTime.Now.ToLongTimeString()}> : {exceptionMessage}\r\n\t{innerException}"
            : $"[Error] <{DateTime.Now.ToShortDateString()} {DateTime.Now.ToLongTimeString()}> : {message}\r\n\t{exceptionMessage}\r\n\t{innerException}";

        if (LogFileInfo != null)
        {
            File.AppendAllText(LogFileInfo.FullName, line + $"\r\n");
        }

        if (OutputToConsole)
        {
            ConsoleColor defaultColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(line);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(stackTrace);
            Console.ForegroundColor = defaultColor;
        }
    }

    public void LogCritical(Exception exception, string? message)
    {
        var exceptionMessage = $"Exception Message:{exception.Message}";
        var innerException = $"Inner Message:{exception.InnerException}";
        var stackTrace = $"Stack Trace:{exception.StackTrace}";
        var line = string.IsNullOrEmpty(message)
            ? $"[Critical] <{DateTime.Now.ToShortDateString()} {DateTime.Now.ToLongTimeString()}> : {exceptionMessage}\r\n\t{innerException}"
            : $"[Critical] <{DateTime.Now.ToShortDateString()} {DateTime.Now.ToLongTimeString()}> : {message}\r\n\t{exceptionMessage}\r\n\t{innerException}";

        if (LogFileInfo != null)
        {
            File.AppendAllText(LogFileInfo.FullName, line + $"\r\n");
        }

        if (OutputToConsole)
        {
            ConsoleColor defaultColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(line);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(stackTrace);
            Console.ForegroundColor = defaultColor;
        }
    }
}

/// <summary>
/// Determines level of logging you want to track in your log
/// </summary>
public enum LogLevel
{
    Debug,
    Information,
    Warning,
    Trace,
    Error,
    Critical
}