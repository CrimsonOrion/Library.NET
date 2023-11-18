namespace Library.NET.Logging;

/// <summary>
/// Custom Logger that displays and/or writes messages to a log and/or console
/// </summary>
public interface ICustomLogger
{
    /// <summary>
    /// <see cref="FileInfo"/> for the log file. Can be <c>null</c> to display only on the console.
    /// </summary>
    FileInfo? LogFileInfo { get; set; }
    /// <summary>
    /// Set the log level to filter the information that gets passed to the logger.
    /// </summary>
    /// <value>Debug, Informational, Warning, Trace, Error, Critical</value>
    LogLevel LogLevel { get; set; }
    /// <summary>
    /// Sets if you want log data to output to the console.
    /// </summary>
    bool OutputToConsole { get; set; }

    /// <summary>
    /// Creates a log entry with <see cref="Logging.LogLevel.Debug"/> with the attached <paramref name="message"/>.
    /// </summary>
    /// <param name="message">Message you want to appear with this entry</param>
    void LogDebug(string message);

    /// <summary>
    /// Creates a log entry with <see cref="Logging.LogLevel.Information"/> with the attached <paramref name="message"/>.
    /// </summary>
    /// <param name="message">Message you want to appear with this entry</param>
    void LogInformation(string message);

    /// <summary>
    /// Creates a log entry with <see cref="Logging.LogLevel.Warning"/> with the attached <paramref name="message"/> and <see cref="Exception.Message"/>. 
    /// </summary>
    /// <param name="exception"></param>
    /// <param name="message"></param>
    void LogWarning(Exception exception, string? message);

    /// <summary>
    /// Creates a log entry with <see cref="Logging.LogLevel.Trace"/> with the attached <paramref name="message"/>, <see cref="Exception.Message"/> and <see cref="Exception.InnerException"/>. <see cref="Exception.StackTrace"/> is displayed in the console if the <see cref="OutputToConsole"/> is set to <c>true</c>.
    /// </summary>
    /// <param name="exception">The caught <see cref="Exception"/></param>
    /// <param name="message">Optional message you want to appear with this entry</param>
    void LogTrace(Exception exception, string? message);

    /// <summary>
    /// Creates a log entry with <see cref="Logging.LogLevel.Error"/> with the attached <paramref name="message"/>, <see cref="Exception.Message"/> and <see cref="Exception.InnerException"/>. <see cref="Exception.StackTrace"/> is displayed in the console if the <see cref="OutputToConsole"/> is set to <c>true</c>.
    /// </summary>
    /// <param name="exception">The caught <see cref="Exception"/></param>
    /// <param name="message">Optional message you want to appear with this entry</param>
    void LogError(Exception exception, string? message);

    /// <summary>
    /// Creates a log entry with <see cref="Logging.LogLevel.Critical"/> with the attached <paramref name="message"/>, <see cref="Exception.Message"/> and <see cref="Exception.InnerException"/>. <see cref="Exception.StackTrace"/> is displayed in the console if the <see cref="OutputToConsole"/> is set to <c>true</c>.
    /// </summary>
    /// <param name="exception">The caught <see cref="Exception"/></param>
    /// <param name="message">Optional message you want to appear with this entry</param>
    void LogCritical(Exception exception, string? message);
}