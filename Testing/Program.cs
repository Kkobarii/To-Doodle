using DataLayer;
using DataLayer.Models;
using Task = DataLayer.Models.Task;

namespace Testing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Database.Execute("insert into [User](username, password) values ('admin', 'admin');");
            //Console.WriteLine(Database.ExecuteScalar("select count(*) from [User];"));
            Database db = new Database();
            //db.Users.Add(new User { Username = "admin", Password = "admin" });
            User u = db.Users.FirstOrDefault();
            Console.WriteLine(u);
            //Console.WriteLine(u.Username);
            foreach (Task t in db.Tasks) { Console.WriteLine(t); }

            db.SaveChanges();
        }
    }
}