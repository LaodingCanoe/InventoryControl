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

namespace InventoryControl
{
    /// <summary>
    /// Логика взаимодействия для Components.xaml
    /// </summary>
    public partial class Components : Page
    {
        private string connectionString = "Data Source=tcp:94.41.21.203,49172;Database=InventoryControl;User Id=Inventory_Admin;Password=Admin007;";
        //private string connectionString = "Data Source=tcp:mssql-server.ddns.net,49172;Initial Catalog=Capital_Life_Insurance_LLC;User Id=Admin;Password=Qwerty1;";

        public Components()
        {
            InitializeComponent();
        }
        private void ConnectToDatabase()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    MessageBox.Show("Connection opened successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                    // Извлечение данных из таблицы Users
                    string query = "SELECT Название FROM Склад";
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    List<string> users = new List<string>();
                    while (reader.Read())
                    {
                        users.Add(reader["Название"].ToString());
                    }

                    // Отображение данных в ListBox
                    UsersListBox.ItemsSource = users;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ConnectToDatabase();
        }
    }
}
