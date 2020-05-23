using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ItemApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static ItemRepository.ItemRepository itemRepository;

        static App()
        {
            itemRepository = new ItemRepository.ItemRepository();
        }

        public static ItemRepository.ItemRepository ItemRepository
        {
            get
            {
                return itemRepository;
            }
        }
    }
}
