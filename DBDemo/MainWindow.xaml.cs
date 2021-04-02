using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace DBDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<InventoryItem> items = new List<InventoryItem>();
        InventoryItemsService service = new InventoryItemsService();
        public MainWindow()
        {
            InitializeComponent();
            RefreshView();
            lbItems.SelectedIndex = 0;
            ShowSelectedItem();
        }

        private void RefreshView()
        {
            items = service.GetAll();
            lbItems.ItemsSource = items;
            lbItems.Items.Refresh();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            ShowSelectedItem();
        }

        private void lbItems_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ShowSelectedItem();
        }

        private void ShowSelectedItem()
        {
            InventoryItem item = (InventoryItem)lbItems.SelectedItem;
            txbId.Text = item.Id.ToString();
            txbName.Text = item.Name;
            txbLocation.Text = item.Location.ToString();
            txbWeight.Text = item.Weight.ToString();
            txbCost.Text = item.Cost.ToString("c");
            txbRemarks.Text = item.Remarks;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            InventoryItem item = new InventoryItem();
            item.Name = txbName.Text;
            item.Location = int.Parse(txbLocation.Text);
            item.Weight = double.Parse(txbWeight.Text);
            item.Cost = Decimal.Parse(txbCost.Text,System.Globalization.NumberStyles.Currency);
            item.Remarks = txbRemarks.Text;
            service.AddItem(item);
            RefreshView();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            InventoryItem itemToDelete = (InventoryItem) lbItems.SelectedItem;
            service.DeleteItem(itemToDelete.Id);
            RefreshView();

        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            InventoryItem item = new InventoryItem();
            item.Id = int.Parse(txbId.Text);
            item.Name = txbName.Text;
            item.Location = int.Parse(txbLocation.Text);
            item.Weight = double.Parse(txbWeight.Text);
            item.Cost = Decimal.Parse(txbCost.Text, System.Globalization.NumberStyles.Currency);
            item.Remarks = txbRemarks.Text;
            service.UpdateItem(item);
            RefreshView();
        }
    }
}
