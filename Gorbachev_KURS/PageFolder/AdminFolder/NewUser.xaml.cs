using Gorbachev_KURS.Cab;
using Gorbachev_KURS.ClassFolder;
using Gorbachev_KURS.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Gorbachev_KURS.PageFolder.AdminFolder
{
    /// <summary>
    /// Логика взаимодействия для NewUser.xaml
    /// </summary>
    public partial class NewUser : Window
    {

        private ObservableCollection<UserData> userDataList = new ObservableCollection<UserData>();


        private string connectionString = ConnectionStringClass.ConnctionLine;

        public object UserGrid { get; private set; }

        public NewUser()
        {
            InitializeComponent();

            
        }




        private void save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string login = LoginTxb.Text;
                string password = PassTxb.Text;
                string selectedRole = ((ComboBoxItem)CmbRole.SelectedItem).Content.ToString();

                int roleId = GetRoleIdByName(selectedRole);

                InsertUser(login, password, roleId);

                MessageBox.Show("Пользователь успешно добавлен в базу данных.", "Успешное добавление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private int GetRoleIdByName(string roleName)
        {
            int roleId = -1;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT Role_ID FROM Roles WHERE Role_Name = @roleName";
                Console.WriteLine("Executing query: " + query); // Вывод SQL-запроса

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@roleName", roleName);
                    Console.WriteLine("Parameter values: roleName = " + roleName); // Вывод параметра

                    var result = command.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        roleId = Convert.ToInt32(result);
                    }
                }
            }

            return roleId;
        }

        private void InsertUser(string login, string password, int roleId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "INSERT INTO [Users] (Login, Password, Role_ID) VALUES (@login, @password, @roleId)";
                Console.WriteLine("Executing query: " + query); // Вывод SQL-запроса

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@login", login);
                    command.Parameters.AddWithValue("@password", password);
                    command.Parameters.AddWithValue("@roleId", roleId);
                    Console.WriteLine("Parameter values: login = " + login + ", password = " + password + ", roleId = " + roleId); // Вывод параметров

                    command.ExecuteNonQuery();
                }
            }
        }


     
        




        private void Back_Click(object sender, RoutedEventArgs e)
        {
            new CabAdmin().Show();
            Close();
        }

    }
}
