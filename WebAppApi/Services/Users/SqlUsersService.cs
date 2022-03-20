using WebAppApi.DbContexts;
using WebAppApi.Models;

namespace WebAppApi.Services.Users
{
    public class SqlUsersService : IUsersService
    {
        private readonly WebAppDbContext _webAppDbContext;

        public SqlUsersService(WebAppDbContext webAppDbContext)
        {
            if (webAppDbContext.Users == null)
            {
                throw new ArgumentNullException(nameof(WebAppDbContext.Users));
            }

            _webAppDbContext = webAppDbContext;
        }

        public void AddUser(UserRegister newUser)
        {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            _webAppDbContext.Users.Add(newUser);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            _webAppDbContext.SaveChanges();
        }

        public UserRegister? GetUser(string username)
        {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            return _webAppDbContext.Users.Find(username);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
        }
    }
}