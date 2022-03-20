using WebAppApi.Models;

namespace WebAppApi.Services.Users
{
    public interface IUsersService
    {
        void AddUser(UserRegister newUser);

        UserRegister? GetUser(string username);
    }
}