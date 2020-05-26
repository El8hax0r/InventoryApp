using System;
using System.Windows;
using ItemApp.Models;

namespace ItemApp
{
    /// <summary>
    /// Interaction logic for DeleteWindow.xaml
    /// </summary>
    public partial class DeleteWindow : Window
    {
        public DeleteWindow()
        {
            InitializeComponent();

            // Don't show this window in the task bar
            ShowInTaskbar = false;
        }

        public ItemModel Item { get; set; }

        private void uxSubmit_Click(object sender, RoutedEventArgs e)
        {
            Item = new ItemModel();

            Item.ItemNumber = Convert.ToInt32(uxItemNumber.Text);

            // This is the return value of ShowDialog( ) below
            DialogResult = true;
            Close();
        }

        private void uxCancel_Click(object sender, RoutedEventArgs e)
        {
            // This is the return value of ShowDialog( ) below
            DialogResult = false;
            Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (Item != null)
            {
                uxSubmit.Content = "Update";
            }
            else
            {
                Item = new ItemModel();
                Item.CreatedDate = DateTime.Now;
            }
        }
    }
}
