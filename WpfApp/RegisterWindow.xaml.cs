using BusinessLayer;
using DataLayer.Models;
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

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();
        }

        private void lblRegister_Click(object sender, RoutedEventArgs e)
        {
            var loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Password;
            string repeatPassword = txtPasswordRep.Password;

            lblWarning.Content = String.Empty;

            if (String.IsNullOrEmpty(username))
                lblWarning.Content += " Username is required.";
            if (String.IsNullOrEmpty(password) || String.IsNullOrEmpty(repeatPassword))
                lblWarning.Content += " Password is required.";

            if (!String.IsNullOrEmpty(lblWarning.Content.ToString()))
                return;

            string? message = UserService.CheckRegisterData(username, password, repeatPassword);
            if (!String.IsNullOrEmpty(message))
            {
                lblWarning.Content += message;
                return;
            }

            User user = UserService.RegisterUser(username, password);

            Session.User = user;

            var mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
