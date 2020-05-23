using System;
using System.Windows;
using ItemApp.Models;

namespace ItemApp
{
    /// <summary>
    /// Interaction logic for ItemWindow.xaml
    /// </summary>
    public partial class ItemWindow : Window
    {
        public ItemWindow()
        {
            InitializeComponent();

            // Don't show this window in the task bar
            ShowInTaskbar = false;
        }

        public ItemModel Item { get; set; }

        private void uxSubmit_Click(object sender, RoutedEventArgs e)
        {
            Item = new ItemModel();

            Item.ItemNumber = 0; //Convert.ToInt32(uxItemNumber.Text);
            Item.ItemDescription = uxItemDescription.Text;
            Item.PricePerItem = 0; //uxPricePerItem.Text;
            Item.QuantityOnHand = 0; //uxQuantityOnHand;
            //Item.TotalItemsValue = ((Convert.ToDouble(Item.PricePerItem)) * (Convert.ToDouble(Item.QuantityOnHand))).ToString();
            Item.OurCostPerItem = 0; // Convert.ToDouble(uxOurCostPerItem.Text); //used to contain uxOurCostPerItem.Text
            Item.CreatedDate = DateTime.UtcNow; //UTC

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
            uxGrid.DataContext = Item;
        }
    }
}
