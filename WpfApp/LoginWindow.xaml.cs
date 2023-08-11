using BusinessLayer.Interfaces;
using DataLayer.Models;
using System;
using System.Windows;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private readonly ITaskService taskService;
        private readonly IUserService userService;

        public LoginWindow(ITaskService taskService, IUserService userService)
        {
            InitializeComponent();
            txtUsername.Focus();
            this.taskService = taskService;
            this.userService = userService;
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

            User? user = userService.CheckLogin(username, password);

            if (user == null)
            {
                lblWarning.Content += "Incorrect credentials.";
                return;
            }

            Session.User = user;

            var mainWindow = new MainWindow(taskService, userService);
            mainWindow.Show();
            this.Close();
        }

        private void lblRegister_Click(object sender, RoutedEventArgs e)
        {
            var registerWindow = new RegisterWindow(taskService, userService);
            registerWindow.Show();
            this.Close();
        }
    }
}
