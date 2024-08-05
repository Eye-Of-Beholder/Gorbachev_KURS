using Gorbachev_KURS.Cab;
using Gorbachev_KURS.ClassFolder;
using Gorbachev_KURS.Model;
using Gorbachev_KURS.PageFolder.ClientFolder;
using Org.BouncyCastle.Asn1.X509;
using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using StackExchange.Redis;


namespace Gorbachev_KURS.PageFolder.AdminFolder
{
    /// <summary>
    /// Логика взаимодействия для Orders.xaml
    /// </summary>
    public partial class Orders : Window
    {


        private string connectionString = ConnectionStringClass.ConnctionLine;



        public Orders()
        {
            InitializeComponent();
            LoadData();
        }

      



        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            new CabAdmin().Show();
            Close();
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (UserGrid.SelectedItems.Count > 0)
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        foreach (var selectedItem in UserGrid.SelectedItems)
                        {
                            if (selectedItem is ClassFolder.OrderClass order)
                            {
                                string deleteQuery = $"DELETE FROM Orders WHERE Order_ID = {order.OrderID}";

                                using (SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection))
                                {
                                    deleteCommand.ExecuteNonQuery();
                                    // Удаляем запись из ObservableCollection
                                    (UserGrid.ItemsSource as ObservableCollection<ClassFolder.OrderClass>).Remove(order);
                                }
                            }
                        }

                        MessageBox.Show("Выбранные записи успешно удалены.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Произошла ошибка при удалении: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Выберите записи для удаления.", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void LoadData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT Order_ID, Device_Type, Device_Model, Problem, Name, Phone, Email FROM Orders";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        ObservableCollection<OrderClass> orders = new ObservableCollection<OrderClass>();

                        while (reader.Read())
                        {
                            int orderID = reader.GetInt32(0);
                            string deviceType = reader.GetString(1);
                            string deviceModel = reader.GetString(2);
                            string problem = reader.GetString(3);
                            string name = reader.GetString(4);
                            string phone = reader.GetString(5);
                            string email = reader.GetString(6);

                            orders.Add(new OrderClass { OrderID = orderID, DeviceType = deviceType, DeviceModel = deviceModel, Problem = problem, Name = name, Phone = phone, Email = email });
                        }

                        UserGrid.ItemsSource = orders; // Привязка к DataGrid
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

}
}


