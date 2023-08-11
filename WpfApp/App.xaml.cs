using BusinessLayer;
using BusinessLayer.Interfaces;
using System.Windows;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            ITaskService taskService = new TaskService();
            IUserService userService = new UserService();

            LoginWindow loginWindow = new LoginWindow(taskService, userService);
            loginWindow.Show();
        }
    }
}
