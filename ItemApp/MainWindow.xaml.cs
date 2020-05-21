using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ItemApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
        //Program Must:
    //Add an item
    //Change an item(by giving its item number not an array index)
    //Delete an item(by giving its item number not an array index)
    //List all items in the database
    //Quit

    //Example inventory item:
    //Item # (int)
    //Description
    //Price per item(double)
    //Quantity on hand(int)
    //Our cost per item(double)
    //Value of item(calculated: price* quantity on hand)
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void uxFileNew_Click(object sender, RoutedEventArgs e)
        {
            var window = new ItemWindow();

            if (window.ShowDialog() == true)
            {
                var uiItemModel = window.Item;

                var repositoryItemModel = uiItemModel.ToRepositoryModel();

                App.ItemRepository.Add(repositoryItemModel);

                // OR
                //App.ContactRepository.Add(window.Contact.ToRepositoryModel());
            }
        }

        private void uxFileChange_Click(object sender, RoutedEventArgs e)
        {

        }

        private void uxFileDelete_Click(object sender, RoutedEventArgs e)
        {

        }
        private void uxList_Click(object sender, RoutedEventArgs e)
        {

        }

        private void uxQuit_Click(object sender, RoutedEventArgs e)
        {

        }
        private void uxItemList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void GridViewColumnHeader_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
