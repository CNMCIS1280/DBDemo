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
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            string connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Rob011235\source\repos\rgarner7cnmedu\CIS1280\CIS1280Demos\DBDemo\DBDemo\DemoDB.mdf;Integrated Security=True";

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                //get data from database 
                string select = "SELECT * FROM InventoryItem;";
                SqlCommand cmd = new SqlCommand(select, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string name = reader.GetString(1);
                    int location = reader.GetInt32(2);
                    double weight = reader.GetDouble(3);
                    decimal cost = reader.GetDecimal(4);
                    string remarks = reader.GetString(5);

                    //display it
                    txbResults.Text += $"{id}: {name} {location} {weight} {cost} \n{remarks}\n";
                }
                conn.Close();                
            }
        }
    }
}
