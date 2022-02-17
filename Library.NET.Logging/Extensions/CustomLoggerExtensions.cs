using System.Diagnostics;

namespace Library.NET.Logging;
public static class CustomLoggerExtensions
{
    public static void LogDebug(this ICustomLogger logger, string message)
    {
        if (logger.LogLevel <= LogLevel.Debug)
        {
            var line = $"[Debug] <{DateTime.Now.ToShortDateString()} {DateTime.Now.ToLongTimeString()}> : {message}";
            Debug.WriteLine(line);
            if (logger.OutputToConsole)
            {
                var defaultColor = Console.ForegroundColor;
                Console.ForegroundColor = defaultColor; // Don't change the color.
                Console.WriteLine(line);
                Console.ForegroundColor = defaultColor;
            }
        }
    }

    public static void LogInformation(this ICustomLogger logger, string message)
    {
        if (logger.LogLevel <= LogLevel.Information)
        {
            var line = $"[Information] <{DateTime.Now.ToShortDateString()} {DateTime.Now.ToLongTimeString()}> : {message}";
            File.AppendAllText(logger.LogFileInfo.FullName, line + $"\r\n");
            if (logger.OutputToConsole)
            {
                var defaultColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(line);
                Console.ForegroundColor = defaultColor;
            }
        }
    }

    public static void LogWarning(this ICustomLogger logger, Exception exception, string message)
    {
        if (logger.LogLevel <= LogLevel.Warning)
        {
            var exceptionMessage = $"Exception Message:{exception.Message}";
            var line = $"[Warning] <{DateTime.Now.ToShortDateString()} {DateTime.Now.ToLongTimeString()}> : {message}\r\n\t{exceptionMessage}";
            File.AppendAllText(logger.LogFileInfo.FullName, line + $"\r\n");
            if (logger.OutputToConsole)
            {
                var defaultColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(line);
                Console.ForegroundColor = defaultColor;
            }
        }
    }

    public static void LogTrace(this ICustomLogger logger, Exception exception, string message)
    {
        if (logger.LogLevel <= LogLevel.Trace)
        {
            var exceptionMessage = $"Exception Message:{exception.Message}";
            var innerException = $"Inner Message:{exception.InnerException}";
            var stackTrace = $"Stack Trace:{exception.StackTrace}";
            var line = $"[Trace] <{DateTime.Now.ToShortDateString()} {DateTime.Now.ToLongTimeString()}> : {message}\r\n\t{exceptionMessage}\r\n\t{innerException}";
            File.AppendAllText(logger.LogFileInfo.FullName, line + $"\r\n");
            if (logger.OutputToConsole)
            {
                var defaultColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(line);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(stackTrace);
                Console.ForegroundColor = defaultColor;
            }
        }
    }

    public static void LogError(this ICustomLogger logger, Exception exception, string message)
    {
        if (logger.LogLevel <= LogLevel.Error)
        {
            var exceptionMessage = $"Exception Message:{exception.Message}";
            var innerException = $"Inner Message:{exception.InnerException}";
            var stackTrace = $"Stack Trace:{exception.StackTrace}";
            var line = $"[Error] <{DateTime.Now.ToShortDateString()} {DateTime.Now.ToLongTimeString()}> : {message}\r\n\t{exceptionMessage}\r\n\t{innerException}";
            File.AppendAllText(logger.LogFileInfo.FullName, line + $"\r\n");
            if (logger.OutputToConsole)
            {
                var defaultColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(line);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(stackTrace);
                Console.ForegroundColor = defaultColor;
            }
        }
    }

    public static void LogCritical(this ICustomLogger logger, Exception exception, string message)
    {
        if (logger.LogLevel <= LogLevel.Critical)
        {
            var exceptionMessage = $"Exception Message:{exception.Message}";
            var innerException = $"Inner Message:{exception.InnerException}";
            var stackTrace = $"Stack Trace:{exception.StackTrace}";
            var line = $"[Critical] <{DateTime.Now.ToShortDateString()} {DateTime.Now.ToLongTimeString()}> : {message}\r\n\t{exceptionMessage}\r\n\t{innerException}";
            File.AppendAllText(logger.LogFileInfo.FullName, line + $"\r\n");
            if (logger.OutputToConsole)
            {
                var defaultColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(line);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(stackTrace);
                Console.ForegroundColor = defaultColor;
            }
        }
    }
}