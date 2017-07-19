using SPKWithTopsis.ViewModels;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TopsisLIB.Models;

namespace SPKWithTopsis
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindowVM viewmodel;

        public MainWindow()
        {
            InitializeComponent();
            this.viewmodel = new MainWindowVM();
            this.DataContext = this.viewmodel;
             viewmodel.MenuVisible = Visibility.Hidden;
            viewmodel.UserText = "Login";

        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            var form = new Forms.LaptopDataView();
            form.ShowDialog();
        }



        private void producent_click(object sender, RoutedEventArgs e)
        {
            var form = new Forms.ProducentDataView();
            form.ShowDialog();
        }

        private void SearchLaptop(object sender, RoutedEventArgs e)
        {
            var form = new Forms.LaptopSearchView();
            form.ShowDialog();
        }

        private void HandPhoneSearch_click(object sender, RoutedEventArgs e)
        {
            var form = new Forms.HandphoneSearch();
            form.ShowDialog();
        }

        private void HandphoneData_click(object sender, RoutedEventArgs e)
        {
            var form = new Forms.HandphoneDataView();
            form.ShowDialog();
        }

    

        private void Login_Click(object sender, RoutedEventArgs e)
        {

            var form = new Forms.LoginView();
            form.ShowDialog();
            if (form.Model == TopsisLIB.LoginStatus.FirstUser)
            {
                viewmodel.UserLogin = form.UserLogin;
                MessageBox.Show("Selamat Datang, Anda adalah Administartor");
                SetLoginSuccess();
            }
            else if (form.Model == TopsisLIB.LoginStatus.LoginSuccess)
            {

                viewmodel.UserLogin = form.UserLogin;
                MessageBox.Show("Selamat Datang");
                SetLoginSuccess();

            }
            else
            {
                MessageBox.Show("User dan Password Anda Salah", "Perhatian", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void SetLoginSuccess()
        {
           viewmodel.MenuVisible = Visibility.Visible;
            viewmodel.UserText = viewmodel.UserLogin.UserName;
        }


        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            viewmodel.MenuVisible = Visibility.Hidden;
            viewmodel.UserText = "Login";
        }
    }
}
