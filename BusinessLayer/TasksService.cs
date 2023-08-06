using DataLayer;
using DataLayer.Models;
using System.Diagnostics;
using Task = DataLayer.Models.Task;

namespace BusinessLayer
{
    public class TasksService
    {
        public static List<Task> GetUserTasks(User user) 
        {
            Database db = new();
            return db.Tasks.Where(t => t.User.Id == user.Id).ToList();
        }

        public static void DeleteTask(Task task)
        {
            Database db = new();
            db.Tasks.Remove(task);
            db.SaveChanges();
        }

        public static void InsertTask(Task task)
        {
            Database db = new();
            Debug.WriteLine(task);
            task.User = db.Users.Where(u => u.Id == task.User.Id).FirstOrDefault(); // entityframework tried inserting the session user as a new 

            db.Tasks.Add(task);

            db.SaveChanges();
        }

        public static void UpdateTask(Task task)
        {
            Database db = new();
            db.Tasks.Update(task);
            db.SaveChanges();
        }
    }
}
