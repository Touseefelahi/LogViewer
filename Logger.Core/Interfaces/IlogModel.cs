using System;

namespace Logger.Core
{
    /// <summary>
    /// Log model interface
    /// </summary>
    public interface ILogModel
    {
        /// <summary>
        /// Message to log
        /// </summary>
        string Message { get; set; }

        /// <summary>
        /// Line number where log coming from (Sets automatically using Reflection)
        /// </summary>
        int LineNumber { get; set; }

        /// <summary>
        /// File path where log coming from (Sets automatically using Reflection)
        /// </summary>
        string FilePath { get; set; }

        /// <summary>
        /// Origin of Log (Sets automatically using Reflection)
        /// </summary>
        string Origin { get; set; }

        /// <summary>
        /// Level to filter out logs
        /// </summary>
        LogLevel Level { get; set; }

        /// <summary>
        /// Log time
        /// </summary>
        TimeSpan Time { get; set; }
    }
}