using System;
using System.Threading.Tasks;
using System.Windows;

namespace TestApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Logger.Core.Logger logger;

        public MainWindow()
        {
            InitializeComponent();
            int loopCount = 50_000;
            int delayedLoopCount = 100;
            logger = new Logger.Core.Logger
            {
                LogLimit = 500000,
            };
            LogView.DataContext = new Logger.Core.LogControlViewModel(logger);
            logger.Log("Test App working");
            logger.Log("Test1 App working");
            logger.Log("Test2 App working");

            Task.Run(async () =>
            {
                for (int i = 0; i < delayedLoopCount; i++)
                {
                    logger.Log($"Delayed loop test - from {i} task");
                    await Task.Delay(10);
                    ShowException();
                }
            });
            Task.Run(() =>
            {
                Parallel.For(0, loopCount, (a) =>
                {
                    logger.Log($"First loop test - from {a} task");
                });
            });
            Task.Run(() =>
            {
                Parallel.For(0, loopCount, (a) =>
                {
                    logger.Log($"Second loop test - from {a} task");
                });
            });
            Task.Run(() =>
            {
                Parallel.For(0, loopCount, (a) =>
                {
                    logger.Log($"Third loop test - from {a} task");
                });
            });
        }

        private void ShowException()
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                logger.Log(ex);
            }
        }
    }
}