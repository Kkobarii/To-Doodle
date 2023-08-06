using BusinessLayer;
using DataLayer.Models;
using Microsoft.IdentityModel.Tokens;
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

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
            txtUsername.Focus();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Password;

            lblWarning.Content = String.Empty;

            if (String.IsNullOrEmpty(username))
                lblWarning.Content += " Username is required.";
            if (String.IsNullOrEmpty(password))
                lblWarning.Content += " Password is required.";

            if (!String.IsNullOrEmpty(lblWarning.Content.ToString()))
                return;

            User? user = LoginService.CheckLogin(username, password);

            if (user == null)
            {
                lblWarning.Content += "Incorrect credentials";
                return;
            }

            Session.User = user;

            var mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
