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
using StoreInventoryManager.Entities;

namespace StoreInventoryManager
{
    /// <summary>
    /// Interaction logic for AddStoreControl.xaml
    /// </summary>
    public partial class AddStoreControl : UserControl
    {
        public AddStoreControl()
        {
            InitializeComponent();
        }

        private void BtnAddStore_OnClick(object sender, RoutedEventArgs e)
        {
            string storeName = StoreName.Text;
            string storeDescription = StoreDescription.Text;
            bool capitalConverted = decimal.TryParse(StoreCapital.Text, out decimal startingCapital);

            if (capitalConverted)
            {
                var store = new Store()
                {
                    Name = storeName,
                    Description = storeDescription,
                    Capital = startingCapital
                };

                using var context = new StoreContext();

                context.Stores.Add(store);
                context.SaveChanges();
                ClearInputs();
            }
        }

        private void ClearInputs()
        {
            StoreName.Clear();
            StoreDescription.Clear();
            StoreCapital.Clear();
        }
    }
}
