using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Data;

namespace Logger.Core
{
    /// <summary>
    /// Logger core
    /// </summary>
    public class Logger : ILogger, INotifyPropertyChanged
    {
        private object locker;

        /// <summary>
        /// Initialize the logger and gets the synchronization context
        /// </summary>
        public Logger()
        {
            locker = new object();
            Logs = new ObservableCollection<ILogModel>();
            BindingOperations.EnableCollectionSynchronization(Logs, locker);
        }

        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        /// <summary>
        /// Log Level
        /// </summary>
        public LogLevel LogLevel { get; set; } = LogLevel.Warning;

        /// <summary>
        /// Log limit for display
        /// </summary>
        public int LogLimit { get; set; } = 1000;

        /// <summary>
        /// All logs for current instance
        /// </summary>
        public ObservableCollection<ILogModel> Logs { get; set; }

        /// <summary>
        /// Logs info/warning/errors/debug messages
        /// </summary>
        /// <param name="message">Message to log</param>
        /// <param name="level">Log level</param>
        /// <param name="origin">Origin of log</param>
        /// <param name="filePath">File path</param>
        /// <param name="lineNumber">Line number</param>
        public void Log(string message,
                        LogLevel level = LogLevel.Info,
                        [CallerMemberName] string origin = "",
                        [CallerFilePath] string filePath = "",
                        [CallerLineNumber] int lineNumber = 0)
        {
            if ((int)LogLevel < (int)level) { return; }

            Log(new LogModel()
            {
                Message = message,
                FilePath = Path.GetFileName(filePath),
                LineNumber = lineNumber,
                Level = level,
                Origin = origin
            });
        }

        /// <summary>
        /// Logs the exception as a Error level
        /// </summary>
        /// <param name="ex">Exception</param>
        /// <param name="origin">Origin of exception</param>
        /// <param name="filePath">File path</param>
        /// <param name="lineNumber">Line number</param>
        public void Log(Exception ex,
                        [CallerMemberName] string origin = "",
                        [CallerFilePath] string filePath = "",
                        [CallerLineNumber] int lineNumber = 0)
        {
            const LogLevel logLevel = LogLevel.Error;
            if ((int)LogLevel < (int)logLevel) { return; }
            Log(new LogModel()
            {
                Message = $"{ex.Message}{Environment.NewLine}{ex.StackTrace}",
                FilePath = Path.GetFileName(filePath),
                LineNumber = lineNumber,
                Level = logLevel,
                Origin = origin
            });
        }

        /// <summary>
        /// Call this to fire a <see cref="PropertyChanged"/> event
        /// </summary>
        /// <param name="name"></param>
        public void OnPropertyChanged(string name)
        {
            var handler = PropertyChanged;
            handler?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void Log(LogModel logModel)
        {
            lock (locker)
            {
                Logs.Add(logModel);
                if (Logs.Count > LogLimit)
                {
                    Logs.RemoveAt(0);
                }
            }
        }
    }
}