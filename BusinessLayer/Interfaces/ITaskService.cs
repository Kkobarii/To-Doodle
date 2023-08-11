using DataLayer.Models;
using Task = DataLayer.Models.Task;

namespace BusinessLayer.Interfaces
{
    public interface ITaskService
    {
        public List<Task> GetUserTasks(User user);
        public void DeleteTask(Task task);
        public void InsertTask(Task task);
        public void UpdateTask(Task task);
    }
}
