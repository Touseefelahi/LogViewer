using System;
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
            LogView.DataContext = new Logger.Core.ViewModels.LogControlViewModel(logger);
            logger.Log("Test App working");
            ShowException();
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