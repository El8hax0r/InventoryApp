using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
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

            Item.ItemNumber = uxItemNumber.Text;
            Item.ItemDescription = uxItemDescription.Text;
            Item.PricePerItem = uxPricePerItem.Text;
            Item.QuantityOnHand = uxQuantityOnHand.ToString();
            Item.TotalItemsValue = ((Convert.ToDouble(Item.PricePerItem)) * (Convert.ToDouble(Item.QuantityOnHand))).ToString();
            Item.OurCostPerItem = Convert.ToInt32(uxOurCostPerItem); //used to contain uxOurCostPerItem.Text
            Item.CreatedDate = DateTime.Now;

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
    }
}
