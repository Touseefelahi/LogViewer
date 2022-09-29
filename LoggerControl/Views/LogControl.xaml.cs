using System.Collections.Specialized;
using System.Windows;
using System.Windows.Controls;

namespace LoggerControl.Views
{
    /// <summary>
    /// Interaction logic for LogControl
    /// </summary>
    public partial class LogControl : UserControl
    {
        public static readonly DependencyProperty IsDeveloperControlVisibleProperty =
            DependencyProperty.Register("IsDeveloperControlVisible", typeof(bool), typeof(LogControl), new PropertyMetadata(true, OnDeveloperControlVisibilityChanged));

        // Using a DependencyProperty as the backing store for LogCountLimit. This enables
        // animation, styling, binding, etc...

        private bool autoScroll = true;

        public LogControl()
        {
            InitializeComponent();
            ((INotifyCollectionChanged)dataGridLogs.Items).CollectionChanged += CollectionChanged;
        }

        public bool IsDeveloperControlVisible
        {
            get => (bool)GetValue(IsDeveloperControlVisibleProperty);
            set => SetValue(IsDeveloperControlVisibleProperty, value);
        }

        private static void OnDeveloperControlVisibilityChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = (LogControl)d;
            control.DeveloperVisibilityChanged((bool)e.NewValue);
        }

        private static void ScrollToEnd(DataGrid datagrid)
        {
            if (datagrid.Items.Count == 0)
            {
                return;
            }
            datagrid.ScrollIntoView(datagrid.Items[datagrid.Items.Count - 1]);
        }

        private void CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (autoScroll)
            {
                ScrollToEnd(dataGridLogs);
            }
        }

        private void DeveloperVisibilityChanged(bool newValue)
        {
            IsDeveloperControlVisible = newValue;
            if (IsDeveloperControlVisible)
            {
                Sender.Visibility = Visibility.Visible;
                Origin.Visibility = Visibility.Visible;
                Line.Visibility = Visibility.Visible;
            }
            else
            {
                Sender.Visibility = Visibility.Collapsed;
                Origin.Visibility = Visibility.Collapsed;
                Line.Visibility = Visibility.Collapsed;
            }
        }

        /// <summary>
        /// Auto Scroll
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItem_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            autoScroll = !autoScroll;
        }
    }
}