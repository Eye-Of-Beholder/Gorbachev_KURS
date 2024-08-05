using Gorbachev_KURS.Cab;
using Gorbachev_KURS.Model;
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
using System.Data.SqlClient;
using Gorbachev_KURS.ClassFolder;

namespace Gorbachev_KURS.MainWindow
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {

        private string connectionString = ConnectionStringClass.ConnctionLine;


        public Registration()
        {
            InitializeComponent();
        }

        private void Reg_Click(object sender, RoutedEventArgs e)
        {
            {
                // Получаем данные из полей ввода
                string log = ButLog.Text.Trim();
                string pas = ButPas.Password.Trim();
                string pasDob = ButPasDob.Password.Trim();

                // Проверяем корректность данных
                if (log.Length < 5)
                {
                    ButLog.ToolTip = "Логин должен содержать не менее 5 символов!";
                    ButLog.Background = Brushes.DarkRed;
                    return;
                }
                else
                {
                    ButLog.ToolTip = "";
                    ButLog.Background = Brushes.Transparent;
                }

                if (pas.Length < 5)
                {
                    ButPas.ToolTip = "Пароль должен содержать не менее 5 символов!";
                    ButPas.Background = Brushes.DarkRed;
                    return;
                }
                else
                {
                    ButPas.ToolTip = "";
                    ButPas.Background = Brushes.Transparent;
                }

                if (pasDob != pas)
                {
                    ButPasDob.ToolTip = "Пароли не совпадают!";
                    ButPasDob.Background = Brushes.DarkRed;
                    return;
                }
                else
                {
                    ButPasDob.ToolTip = "";
                    ButPasDob.Background = Brushes.Transparent;
                }
                string login = ButLog.Text;
                string password = ButPas.Password;
                string repeatedPassword = ButPasDob.Password;

                if (password == repeatedPassword)
                {
                    try
                    {
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();

                            string insertQuery = "INSERT INTO Users (Password, Login, Role_ID) VALUES (@Password, @Login, @Role_ID)";

                            using (SqlCommand insertCommand = new SqlCommand(insertQuery, connection))
                            {
                                insertCommand.Parameters.AddWithValue("@Password", password);
                                insertCommand.Parameters.AddWithValue("@Login", login);
                                insertCommand.Parameters.AddWithValue("@Role_ID", 2); // Здесь 2 - это ID роли пользователя, уточните это значение для вашей базы данных.

                                int rowsAffected = insertCommand.ExecuteNonQuery();
                                if (rowsAffected > 0)
                                {
                                    MessageBox.Show("Пользователь успешно зарегистрирован.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                                }
                                else
                                {
                                    MessageBox.Show("Не удалось зарегистрировать пользователя.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Произошла ошибка при регистрации: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Пароли не совпадают. Повторите ввод пароля.", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
                }

            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new Authorization().Show();
            Close();
        }
    }
}
