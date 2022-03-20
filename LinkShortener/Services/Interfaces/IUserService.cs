using LinkShortener.Model;

namespace LinkShortener.Services.Interfaces
{
    public interface IUserService
    {
        public void RegisterNewUser(User user);

        public bool DoesUserNameExist(string userName);

        public User? GetUser(string userName, string password);

        public User? GetUserById(int id);
    }
}
