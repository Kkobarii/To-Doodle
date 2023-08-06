using BusinessLayer;
using DataLayer;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
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
                return TasksService.GetUserTasks(Session.User!);
            }
            set
            {
                tasks = value;
            }
        }
        public MainWindow()
        {
            InitializeComponent();
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
            var loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close();
        }

        private void New_Task_Button_Click(object sender, RoutedEventArgs e)
        {
            var detailWindow = new DetailWindow(null);
            detailWindow.ShowDialog();
        }

        private void Edit_Task_Button_Click(object sender, RoutedEventArgs e)
        {
            Task task = (Task)TasksGrid.SelectedItem;

            if (task == null)
                return;

            var detailWindow = new DetailWindow(task);
            detailWindow.ShowDialog();
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            Load_Grid();
        }
    }
}
