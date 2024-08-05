using Gorbachev_KURS.Model;
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
using System.Net;
using Gorbachev_KURS.PageFolder.ClientFolder;
using System.Data;
using System.Configuration;
using Gorbachev_KURS.ClassFolder;
using Gorbachev_KURS.MainWindow;


namespace Gorbachev_KURS.Cab
{
    /// <summary>
    /// Логика взаимодействия для CabUser.xaml
    /// </summary>
    public partial class CabUser : Window
    {
        public CabUser()
        {
            InitializeComponent();

        }





        private void addOrder_Click(object sender, RoutedEventArgs e)
        {
            new AddOrder().Show();
            Close();
        }


        private void Close_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow.Authorization().Show();
            Close();
        }
    }

    }


