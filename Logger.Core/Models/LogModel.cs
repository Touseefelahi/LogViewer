using System;

namespace Logger.Core
{
    public class LogModel : ILogModel
    {
        public string Message { get; set; }
        public int LineNumber { get; set; }
        public string FilePath { get; set; }
        public string Origin { get; set; }
        public LogLevel Level { get; set; }
        public TimeSpan Time { get; set; }

        public LogModel()
        {
            Time = DateTime.Now.TimeOfDay;
        }
    }
}
