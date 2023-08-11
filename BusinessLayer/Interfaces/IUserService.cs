using DataLayer.Models;

namespace BusinessLayer.Interfaces
{
    public interface IUserService
    {
        public User? CheckLogin(string username, string password);
        public string? CheckRegisterData(string username, string password, string repeatPassword);
        public User RegisterUser(string username, string password);
    }
}
