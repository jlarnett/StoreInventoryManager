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

namespace StoreInventoryManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnStore_Click(object sender, RoutedEventArgs e)
        {
            SetActiveUserControlWindow(StoreControl);
            StoreItemControl.RefreshStores();
        }

        private void BtnStoreItem_Click(object sender, RoutedEventArgs e)
        {
            SetActiveUserControlWindow(StoreItemControl);
            StoreItemControl.RefreshStores();
        }

        private void BtnDisplayItems_Click(object sender, RoutedEventArgs e)
        {
            SetActiveUserControlWindow(DisplayItemsControl);
        }

        /// <summary>
        /// Changes the active control window visibility
        /// </summary>
        /// <param name="control">the user control that should be active</param>
        private void SetActiveUserControlWindow(UserControl control)
        {
            //Sets all control visibilities
            StoreControl.Visibility = Visibility.Collapsed;
            StoreItemControl.Visibility = Visibility.Collapsed;
            DisplayItemsControl.Visibility = Visibility.Collapsed;

            //Sets the passed in control parameter visibility to ON.
            control.Visibility = Visibility.Visible;
        }
    }
}
