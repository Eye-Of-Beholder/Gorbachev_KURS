using Gorbachev_KURS.Cab;
using Gorbachev_KURS.ClassFolder;
using Gorbachev_KURS.Model;
using Gorbachev_KURS.PageFolder.AdminFolder;
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
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using MySqlX.XDevAPI;


namespace Gorbachev_KURS.PageFolder.ClientFolder
{
    /// <summary>
    /// Логика взаимодействия для AddOrder.xaml
    /// </summary>
    public partial class AddOrder : Window
    {



        private string connectionString = ConnectionStringClass.ConnctionLine;


        private void add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string deviceType = Model_Type.Text;
                string deviceModel = Model_Device.Text;
                string problem = Problem.Text;
                string name = Name1.Text; // Имя
                string phone = phonebox.Text; // Номер телефона
                string email = mailbox.Text; // Email

                // Создаем подключение к базе данных


                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Создаем SQL-запрос для вставки данных в таблицу Orders
                    string query = "INSERT INTO Orders (Device_Type, Device_Model, Problem, Name, Phone, Email) " +
                                   "VALUES (@Device_Type, @Device_Model, @Problem, @Name, @Phone, @Email)";

                    // Создаем команду
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Добавляем параметры
                        command.Parameters.AddWithValue("@Device_Type", deviceType);
                        command.Parameters.AddWithValue("@Device_Model", deviceModel);
                        command.Parameters.AddWithValue("@Problem", problem);
                        command.Parameters.AddWithValue("@Name", name); // Имя
                        command.Parameters.AddWithValue("@Phone", phone); // Номер телефона
                        command.Parameters.AddWithValue("@Email", email); // Email

                        // Выполняем запрос
                        command.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Заказ успешно добавлен в базу данных.", "Успешное добавление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        






        public AddOrder()
        {
            InitializeComponent();
        }


        private void back_Click(object sender, RoutedEventArgs e)
        {
           new CabUser().Show();
            Close();
        }

        

        private void Orders_Click(object sender, RoutedEventArgs e)
        {
           
        }

       
    }
}


      
