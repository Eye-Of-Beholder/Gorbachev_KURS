using Gorbachev_KURS.Cab;
using System.Windows;
using System.Windows.Navigation;
using System.Data.SqlClient;
using System;
using Gorbachev_KURS.ClassFolder;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Gorbachev_KURS.PageFolder.AdminFolder
{
    /// <summary>
    /// Логика взаимодействия для AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {


        private ObservableCollection<UserData> usersList;


        private string connectionString = ConnectionStringClass.ConnctionLine;



        public AddWindow(ObservableCollection<User> users)
        {
            InitializeComponent();
            usersList = new ObservableCollection<UserData>();
            LoadUserData();
            UserGrid.ItemsSource = usersList;

        }





        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            new CabAdmin().Show();
            Close();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            new NewUser().Show();
            Close();
        }

       
        

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            // Получение выбранной строки в DataGrid
            UserData selectedUser = UserGrid.SelectedItem as UserData;

            if (selectedUser != null)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "DELETE FROM [Users] WHERE User_ID = @userId";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@userId", selectedUser.User_ID);
                        command.ExecuteNonQuery();
                    }

                    // Обновление данных в DataGrid после удаления
                   
                }
            }
        }






        private void LoadUserData()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT User_ID, Login, Password, Role_ID FROM Users";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            UserData user = new UserData
                            {
                                User_ID = reader.GetInt32(0),
                                Login = reader.GetString(1),
                                Password = reader.GetString(2),
                                Role_ID = reader.GetInt32(3)
                            };

                            usersList.Add(user);
                        }
                    }
                }
            }
        }
    }

}
