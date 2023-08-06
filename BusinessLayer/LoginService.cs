using DataLayer;
using DataLayer.Models;
using Task = DataLayer.Models.Task;

namespace BusinessLayer
{
    public class LoginService
    {
        public static User? CheckLogin(string username, string password)
        {
            Database db = new Database();
            var users = db.Users.Where(x => x.Username == username);

            foreach (var user in users)
            {
                if (BCrypt.Net.BCrypt.Verify(password, user.Password))
                    return user;
            }

            return null;
        }
    }
}
