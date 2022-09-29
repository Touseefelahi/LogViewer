namespace Logger.Core
{
    /// <summary>
    /// Log level for filteration
    /// </summary>
    public enum LogLevel
    {
        /// <summary>
        /// Nothing will be logged
        /// </summary>
        Off,

        /// <summary>
        /// Only info will be logged
        /// </summary>
        Info,

        /// <summary>
        /// Error and Info will be logged
        /// </summary>
        Error,

        /// <summary>
        /// Warning, Errors and Info will be logged
        /// </summary>
        Warning,

        /// <summary>
        /// Everything will be logged
        /// </summary>
        Debug,
    }
}