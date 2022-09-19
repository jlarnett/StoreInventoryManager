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
using System.Windows.Threading;
using StoreInventoryManager.DatabaseContext;
using StoreInventoryManager.Entities;

namespace StoreInventoryManager
{
    /// <summary>
    /// Interaction logic for AddStoreItemControl.xaml
    /// </summary>
    public partial class AddStoreItemControl : UserControl
    {

        public AddStoreItemControl()
        {
            InitializeComponent();
        }

        public void RefreshStores()
        {
            using var context = new StoreContext();
            List<Store> stores = context.Stores.ToList();

            cmbStores.Items.Clear();

            foreach (var store in stores)
            {
                var selectList = new SelectListItem();
                selectList.SelectionText = store.Name;
                selectList.SelectionDatabaseId = store.Id;

                cmbStores.Items.Add(selectList);
            }
        }

        public class SelectListItem
        {
            public string SelectionText { get; set; }
            public int SelectionDatabaseId { get; set; }

            public override string ToString()
            {
                return SelectionText;
            }
        }

        private void BtnAddItem_Click(object sender, RoutedEventArgs e)
        {
            using var context = new StoreContext();

            var decimalConverted = decimal.TryParse(ItemCost.Text, out decimal cost);
            var quantiyConverted = int.TryParse(ItemQuantity.Text, out int quantity);

            SelectListItem selectedItem = (SelectListItem)cmbStores.SelectionBoxItem;

            if (decimalConverted && quantiyConverted)
            {
                var item = new StoreItem()
                {
                    Name = ItemName.Text,
                    Price = cost,
                    Description = ItemDescription.Text,
                    RemainingQuantity = quantity,
                    StoreId = selectedItem.SelectionDatabaseId
                };

                context.Items.Add(item);
                context.SaveChanges();

                ClearInputs();
            }
            else
            {
                
            }
        }

        private void ClearInputs()
        {
            ItemCost.Clear();
            ItemDescription.Clear();
            ItemQuantity.Clear();
            ItemName.Clear();
            cmbStores.SelectedIndex = -1;
        }
    }
}
