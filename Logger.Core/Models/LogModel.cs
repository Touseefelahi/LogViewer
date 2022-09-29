using System;

namespace Logger.Core
{
    /// <summary>
    /// Log model for logger
    /// </summary>
    public class LogModel : ILogModel
    {
        /// <summary>
        /// Model sets time on initialization
        /// </summary>
        public LogModel()
        {
            Time = DateTime.Now.TimeOfDay;
        }

        /// <summary>
        /// Message to log
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Line number where log coming from (Sets automatically using Reflection)
        /// </summary>
        public int LineNumber { get; set; }

        /// <summary>
        /// File path where log coming from (Sets automatically using Reflection)
        /// </summary>
        public string FilePath { get; set; }

        /// <summary>
        /// Origin of Log (Sets automatically using Reflection)
        /// </summary>
        public string Origin { get; set; }

        /// <summary>
        /// Level to filter out logs
        /// </summary>
        public LogLevel Level { get; set; }

        /// <summary>
        /// Log time
        /// </summary>
        public TimeSpan Time { get; set; }
    }
}