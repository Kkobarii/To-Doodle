using BusinessLayer.Interfaces;
using DataLayer.Models;
using System;
using System.Windows;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        private readonly ITaskService taskService;
        private readonly IUserService userService;

        public RegisterWindow(ITaskService taskService, IUserService userService)
        {
            InitializeComponent();
            this.taskService = taskService;
            this.userService = userService;
        }

        private void lblRegister_Click(object sender, RoutedEventArgs e)
        {
            var loginWindow = new LoginWindow(taskService, userService);
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

            string? message = userService.CheckRegisterData(username, password, repeatPassword);
            if (!String.IsNullOrEmpty(message))
            {
                lblWarning.Content += message;
                return;
            }

            User user = userService.RegisterUser(username, password);

            Session.User = user;

            var mainWindow = new MainWindow(taskService, userService);
            mainWindow.Show();
            this.Close();
        }
    }
}
