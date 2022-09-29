using System;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;

namespace Logger.Core
{
    /// <summary>
    /// Logger interface
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Log Level
        /// </summary>
        LogLevel LogLevel { get; set; }

        /// <summary>
        /// All logs for current instance
        /// </summary>
        ObservableCollection<ILogModel> Logs { get; set; }

        /// <summary>
        /// Log limit for display
        /// </summary>
        int LogLimit { get; set; }

        /// <summary>
        /// Logs info/warning/errors/debug messages
        /// </summary>
        /// <param name="message">Message to log</param>
        /// <param name="level">Log level</param>
        /// <param name="origin">Origin of log</param>
        /// <param name="filePath">File path</param>
        /// <param name="lineNumber">Line number</param>
        void Log(
         string message,
         LogLevel level = LogLevel.Info,
         [CallerMemberName] string origin = "",
         [CallerFilePath] string filePath = "",
         [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Logs the exception as a Error level
        /// </summary>
        /// <param name="ex">Exception</param>
        /// <param name="origin">Origin of exception</param>
        /// <param name="filePath">File path</param>
        /// <param name="lineNumber">Line number</param>
        void Log(
         Exception ex,
         [CallerMemberName] string origin = "",
         [CallerFilePath] string filePath = "",
         [CallerLineNumber] int lineNumber = 0);
    }
}