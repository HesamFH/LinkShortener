using LinkShortener.Model;
using LinkShortener.Model.Context;
using LinkShortener.Services.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

namespace LinkShortener.Services
{
    public class UserService : IUserService
    {
        private LinkShortenerContext _db;

        public UserService(LinkShortenerContext db)
        {
            _db = db;
        }

        public bool DoesUserNameExist(string userName)
        {
            return _db.User.Any(u => u.UserName == userName);
        }

        public User? GetUser(string userName, string password)
        {
            return _db.User.SingleOrDefault(u => u.UserName == userName && u.Password == password);
        }

        public User? GetUserById(int id)
        {
            return _db.User.FirstOrDefault(u => u.UserId == id);
        }

        public void RegisterNewUser(User user)
        {
            if (!DoesUserNameExist(user.UserName))
            {
                _db.User.Add(user);
                _db.SaveChanges();
            }
        }
    }
}
