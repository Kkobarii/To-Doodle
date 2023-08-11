using BusinessLayer.Interfaces;
using DataLayer;
using DataLayer.Models;

namespace BusinessLayer
{
    public class UserService : IUserService
    {
        public User? CheckLogin(string username, string password)
        {
            Database db = new();
            var users = db.Users.Where(x => x.Username == username);

            foreach (var user in users)
            {
                if (BCrypt.Net.BCrypt.Verify(password, user.Password))
                    return user;
            }

            return null;
        }

        public string? CheckRegisterData(string username, string password, string repeatPassword) 
        {
            if (password != repeatPassword)
            {
                return "Passwords do not match";
            }

            Database db = new();
            if (db.Users.Where(u => u.Username == username).Any())
            {
                return "This username is taken";
            }

            return null;
        }

        public  User RegisterUser(string username, string password)
        {
            Database db = new();
            User user = new User()
            {
                Username = username,
                Password = BCrypt.Net.BCrypt.HashPassword(password),
            };
            db.Users.Add(user);
            db.SaveChanges();
            return user;
        }
    }
}
