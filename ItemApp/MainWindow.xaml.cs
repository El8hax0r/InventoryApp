using System.Windows;
using System.Windows.Controls;
using ItemApp;
using ItemApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            LoadItems();
        }
        private ItemModel selectedItem;
        private void LoadItems()
        {
            var items = App.ItemRepository.GetAll();

            uxItemList.ItemsSource = items //".ItemsSource" is in the example, maybe needs changed?
                .Select(t => ItemModel.ToModel(t)) //.ItemModel.ToModel?
                                                   // or // 
                                                   //.Select(RepositoryItem => ItemModel.ToModel(RepositoryItem))
                .ToList();

            // OR
            //var uiItemModelList = new List<ItemModel>();
            //foreach (var repositoryItemModel in items)
            //{
            //    This is the .Select(t => ... )
            //    var uiItemModel = ItemModel.ToModel(repositoryItemModel);
            //
            //    uiItemModelList.Add(uiItemModel);
            //}

            //uxItemList.ItemsSource = uiItemModelList;
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
                //App.ItemRepository.Add(window.Item.ToRepositoryModel());

                LoadItems();
            }
        }

        private void uxFileChange_Click(object sender, RoutedEventArgs e)
        {
            var window = new ItemWindow();
            window.Item = selectedItem;

            if (window.ShowDialog() == true)
            {
                App.ItemRepository.Update(window.Item.ToRepositoryModel());
                LoadItems();
            }
        }

        private void uxFileDelete_Click(object sender, RoutedEventArgs e)
        {
            App.ItemRepository.Remove(selectedItem.ItemNumber);
            selectedItem = null;
            LoadItems();
        }
        private void uxList_Click(object sender, RoutedEventArgs e)
        {
            LoadItems();
        }

        private void uxQuit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void uxItemList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedItem = (ItemModel)uxItemList.SelectedValue;
        }

        private void GridViewColumnHeader_Click(object sender, RoutedEventArgs e)
        {
            var column = (sender as GridViewColumnHeader);

            string sortBy = column.Tag.ToString();
            //if (listviewsort)
        }

        private void uxFileDelete_Loaded(object sender, RoutedEventArgs e)
        {
            //we're disabling this to allow for anytime selection
            //uxFileDelete.IsEnabled = (selectedItem != null);
        }

        private void uxFileChange_Loaded(object sender, RoutedEventArgs e)
        {
            //we're disabling this to allow for anytime selection
            //uxFileChange.IsEnabled = (selectedItem != null);
            //uxContextFileChange.IsEnabled = uxFileChange.IsEnabled;
        }
    }
}
