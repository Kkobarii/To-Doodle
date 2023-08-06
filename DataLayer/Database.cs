using Microsoft.EntityFrameworkCore;
using DataLayer.Models;
using Task = DataLayer.Models.Task;

namespace DataLayer
{
    public class Database : DbContext
    {
        private static string connectionString = "Server=(localdb)\\mssqllocaldb;Database=master;Trusted_Connection=True;";

        public DbSet<User> Users { get; set; }
        public DbSet<Task> Tasks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(connectionString);
        }
    }
}
