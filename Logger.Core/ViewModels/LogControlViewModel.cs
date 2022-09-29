namespace Logger.Core
{
    /// <summary>
    /// Log control view model for WPF UI
    /// </summary>
    public class LogControlViewModel
    {
        /// <summary>
        /// Base constructor
        /// </summary>
        /// <param name="logger"></param>
        public LogControlViewModel(ILogger logger)
        {
            Logger = logger;
        }

        /// <summary>
        /// Logger
        /// </summary>
        public ILogger Logger { get; set; }
    }
}