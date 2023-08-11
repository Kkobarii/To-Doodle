using BusinessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Windows;
using Task = DataLayer.Models.Task;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Task> tasks 
        { 
            get
            {
                return taskService.GetUserTasks(Session.User!);
            }
            set
            {
                tasks = value;
            }
        }
        private readonly ITaskService taskService;
        private readonly IUserService userService;
        
        public MainWindow(ITaskService taskService, IUserService userService)
        {
            InitializeComponent();
            this.taskService = taskService;
            this.userService = userService;
            lblUsername.Text = Session.User!.Username;
            Load_Grid();
        }

        private void Load_Grid()
        {
            tasks.Clear();
            TasksGrid.DataContext = tasks;
        }

        private void Logout_Button_Click(object sender, RoutedEventArgs e)
        {
            Session.User = null;
            var loginWindow = new LoginWindow(taskService, userService);
            loginWindow.Show();
            this.Close();
        }

        private void New_Task_Button_Click(object sender, RoutedEventArgs e)
        {
            var detailWindow = new DetailWindow(taskService, null);
            detailWindow.ShowDialog();
        }

        private void Edit_Task_Button_Click(object sender, RoutedEventArgs e)
        {
            Task task = (Task)TasksGrid.SelectedItem;

            if (task == null)
                return;

            var detailWindow = new DetailWindow(taskService, task);
            detailWindow.ShowDialog();
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            Load_Grid();
        }
    }
}
