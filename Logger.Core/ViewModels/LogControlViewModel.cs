namespace Logger.Core.ViewModels
{
    public class LogControlViewModel
    {
        public ILogger Logger { get; set; }

        public LogControlViewModel(ILogger logger)
        {
            Logger = logger;
        }
    }
}
