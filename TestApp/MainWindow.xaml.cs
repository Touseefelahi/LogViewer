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
            logger = new Logger.Core.Logger();
            logger.LogLimit = 5;
            LogView.DataContext = new Logger.Core.LogControlViewModel(logger);
            logger.Log("Test App working");
            logger.Log("Test1 App working");
            logger.Log("Test2 App working");
            Task.Run(async () =>
            {
                logger.Log("Test3 App working");
                await Task.Delay(300).ConfigureAwait(false);
                logger.Log("Test4 App working");
                await Task.Delay(300).ConfigureAwait(false);
                ShowException();
                await Task.Delay(300).ConfigureAwait(false);
                logger.Log("Test5 App working");
                await Task.Delay(300).ConfigureAwait(false);
                logger.Log("Test6 App working");
                await Task.Delay(300).ConfigureAwait(false);
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