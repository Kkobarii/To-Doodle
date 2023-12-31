﻿using BusinessLayer.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Windows;
using Task = DataLayer.Models.Task;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for Detail.xaml
    /// </summary>
    public partial class DetailWindow : Window
    {
        private Task? Task { get; set; }
        private readonly ITaskService taskService;

        public DetailWindow(ITaskService taskService, Task? task)
        {
            InitializeComponent();

            this.taskService = taskService;

            if (task == null)
            {
                btnDelete.Visibility = Visibility.Collapsed;
                return;
            }

            Task = task;
            txtTitle.Text = task.Title;
            txtFinished.IsChecked = task.Finished;
            if (task.Description != null) 
                txtDescription.Text = task.Description;
            if (task.Date != null)
                txtDate.Text = task.Date.ToString();
            if (task.Priority != null)
                txtPriority.Text = task.Priority.ToString();
        }

        private void Save_Button_Click(object sender, RoutedEventArgs e)
        {
            lblWarning.Content = String.Empty;
            if (txtTitle.Text.ToString().IsNullOrEmpty())
            {
                lblWarning.Content += "Title is required.";
                return;
            }    

            string title = txtTitle.Text;
            bool finished = txtFinished.IsChecked ?? false;

            Task task = new Task() { Title = title, Finished = finished, Id = null };

            if (!txtDate.Text.ToString().IsNullOrEmpty())
                task.Date = DateTime.Parse(txtDate.Text);

            if (!txtDescription.Text.ToString().IsNullOrEmpty())
                task.Description = txtDescription.Text;

            if (!txtPriority.Text.IsNullOrEmpty())
                task.Priority = int.Parse(txtPriority.Text);

            task.User = Session.User!;

            if (Task == null)
            {
                taskService.InsertTask(task);
            }
            else
            {
                task.Id = Task.Id;
                taskService.UpdateTask(task);
            }

            DialogResult = true;
            Close();
        }

        private void Cancel_Button_Click(object sender, RoutedEventArgs e)
        {
            var result = Xceed.Wpf.Toolkit.MessageBox.Show("Are you sure you want to cancel? All your changes will be lost.", "Confirmation", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.No) { return; }

            DialogResult = false;
            Close();
        }

        private void Delete_Button_Click(object sender, RoutedEventArgs e)
        {
            var result = Xceed.Wpf.Toolkit.MessageBox.Show("Are you sure you want to delete this task?", "Confirmation", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.No) { return; }

            taskService.DeleteTask(Task);

            DialogResult = false;
            Close();
        }
    }
}
