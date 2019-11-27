using System;
using System.Collections.Specialized;
using System.Windows.Controls;

namespace LoggerControl.Views
{
    /// <summary>
    /// Interaction logic for LogControl
    /// </summary>
    public partial class LogControl : UserControl
    {
        private bool autoScroll = true;

        public LogControl()
        {
            InitializeComponent();
            ((INotifyCollectionChanged)dataGridLogs.Items).CollectionChanged += CollectionChanged;
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