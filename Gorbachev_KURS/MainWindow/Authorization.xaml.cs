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
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;
using System.Data.Entity;
using Gorbachev_KURS.Model;
using System.Windows.Navigation;
using MySql.Data.MySqlClient;
using Gorbachev_KURS.Cab;
using Gorbachev_KURS.PageFolder.AdminFolder;
using Gorbachev_KURS.PageFolder.ClientFolder;
using System.Collections.ObjectModel;
using Gorbachev_KURS.ClassFolder;




namespace Gorbachev_KURS.MainWindow
{

    public partial class Authorization : Window
    {


        private string connectionString = ConnectionStringClass.ConnctionLine;



        public Authorization()
        {
            InitializeComponent();

        }

        private void Enter_Click(object sender, RoutedEventArgs e)
        {
            string login = ButLog.Text;
            string password = ButPas.Password;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT Role_ID FROM Users WHERE Login = @Login AND Password = @Password";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Login", login);
                    command.Parameters.AddWithValue("@Password", password);

                    int roleID = Convert.ToInt32(command.ExecuteScalar());

                    if (roleID > 0)
                    {
                        if (roleID == 1) // Администратор
                        {
                            Cab.CabAdmin adminWindow = new Cab.CabAdmin();
                            adminWindow.Show();
                            Close();
                        }
                        else if (roleID == 2) // Пользователь
                        {
                            Cab.CabUser userWindow = new Cab.CabUser();
                            userWindow.Show();
                            Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Неверные логин или пароль.");
                    }
                }
            }
        }

       

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new Registration().Show();
            Close();
        }
    }
}
