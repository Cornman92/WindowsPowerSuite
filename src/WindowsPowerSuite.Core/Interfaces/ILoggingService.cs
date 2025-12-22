namespace WindowsPowerSuite.Core.Interfaces;

/// <summary>
/// Provides centralized logging functionality.
/// </summary>
public interface ILoggingService
{
    /// <summary>
    /// Logs a debug message.
    /// </summary>
    /// <param name="message">The message to log.</param>
    /// <param name="args">Optional message arguments.</param>
    void LogDebug(string message, params object[] args);

    /// <summary>
    /// Logs an informational message.
    /// </summary>
    /// <param name="message">The message to log.</param>
    /// <param name="args">Optional message arguments.</param>
    void LogInformation(string message, params object[] args);

    /// <summary>
    /// Logs a warning message.
    /// </summary>
    /// <param name="message">The message to log.</param>
    /// <param name="args">Optional message arguments.</param>
    void LogWarning(string message, params object[] args);

    /// <summary>
    /// Logs an error with exception details.
    /// </summary>
    /// <param name="exception">The exception to log.</param>
    /// <param name="message">The message to log.</param>
    /// <param name="args">Optional message arguments.</param>
    void LogError(Exception exception, string message, params object[] args);

    /// <summary>
    /// Logs a critical error with exception details.
    /// </summary>
    /// <param name="exception">The exception to log.</param>
    /// <param name="message">The message to log.</param>
    /// <param name="args">Optional message arguments.</param>
    void LogCritical(Exception exception, string message, params object[] args);

    /// <summary>
    /// Flushes all buffered log messages.
    /// </summary>
    void Flush();
}
