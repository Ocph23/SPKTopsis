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
using TopsisLIB;
using TopsisLIB.DataCollections;
using TopsisLIB.Models;

namespace SPKWithTopsis.Forms
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        public string Password { get; private set; }
        public LoginStatus Model { get; private set; }
        public User UserLogin { get; private set; }

        public LoginView()
        {
            InitializeComponent();
        }

        private void password_PasswordChanged(object sender, RoutedEventArgs e)
        {
            var pwsd= (PasswordBox)sender;
            this.Password = pwsd.Password;
        }

        private void Login_btn(object sender, RoutedEventArgs e)
        {
            var dl = new LoginDataAccess();
            var status = dl.Login(textBox.Text, this.Password);
            this.Model = status.LoginStatus;
            this.UserLogin = new User { UserName = textBox.Text };
            this.Close();
        }
    }
}
