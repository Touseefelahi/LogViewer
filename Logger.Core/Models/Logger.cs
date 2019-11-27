using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;

namespace Logger.Core
{
    public class Logger : ILogger, INotifyPropertyChanged
    {
        private readonly SynchronizationContext synchronization;

        public Logger()
        {
            Logs = new ObservableCollection<ILogModel>();
            synchronization = SynchronizationContext.Current;
        }

        public ObservableCollection<ILogModel> Logs { get; set; }
        public LogLevel LogLevel { get; set; } = LogLevel.Warning;

        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

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

        private void Log(LogModel logModel)
        {
            synchronization.Send(_ => Logs.Add(logModel), null);
            OnPropertyChanged(nameof(Logs));
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
    }
}