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
using StoreInventoryManager.DatabaseContext;

namespace StoreInventoryManager
{
    /// <summary>
    /// Interaction logic for DisplayItems.xaml
    /// </summary>
    public partial class DisplayItems : UserControl
    {
        public DisplayItems()
        {
            InitializeComponent();
            RetrieveItems();
        }

        public void RetrieveItems()
        {
            using var context = new StoreContext();

            //Query store database table & convert to list
            var stores = context.Stores.ToList();

            foreach (var store in stores)
            {
                string customStoreString = store.Id + " : " + store.Name + " : " + store.Description + " : " + store.Capital;
                ItemList.Items.Add(customStoreString);
            }

            //Query storeItem database table using LINQ lambda expression
            var items = context.Items.Where(i => i.Description.Contains("paper"));

            foreach (var item in items)
            {
                string customStoreString = item.Id + " : " + item.Name + " : " + item.Description + " : " + item.Price;
                ItemList.Items.Add(customStoreString);
            }

        }
    }
}
