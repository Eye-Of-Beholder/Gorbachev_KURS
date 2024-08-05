using Gorbachev_KURS.ClassFolder;
using Gorbachev_KURS.MainWindow;
using Gorbachev_KURS.PageFolder.AdminFolder;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Gorbachev_KURS.Cab
{
    /// <summary>
    /// Логика взаимодействия для CabAdmin.xaml
    /// </summary>
    public partial class CabAdmin : Window
    {
       

        public CabAdmin()
        {
            InitializeComponent();
        }



        private void New_User_Click(object sender, RoutedEventArgs e)
        {
            new NewUser().Show();
            Close();
        }

        private void AddWindow_Click(object sender, RoutedEventArgs e)
        {
            ObservableCollection<User> users = new ObservableCollection<User>(); // Создаем пустую коллекцию
            new AddWindow(users).Show(); // Передаем коллекцию в конструктор AddWindow
            Close();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            new Authorization().Show();
            Close();
        }

        private void Orders_Click(object sender, RoutedEventArgs e)
        {
            new PageFolder.AdminFolder.Orders().Show();
            Close();
        }
    }
}
