namespace Logger.Core
{
    public class LogControlViewModel
    {
        public LogControlViewModel(ILogger logger)
        {
            Logger = logger;
        }

        public ILogger Logger { get; set; }
    }
}