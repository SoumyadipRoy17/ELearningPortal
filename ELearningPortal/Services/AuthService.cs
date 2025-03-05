using ElearningPortal.Database;
using ElearningPortal.Models;

namespace ElearningPortal.Services
{
    public class AuthService : IAuthService
    {
        private readonly IDatabase _db;

        public AuthService(IDatabase db)
        {
            _db = db;
        }

        public User Login(string username, string password)
        {
            var user = _db.GetUser(username);
            return user != null && user.Password == password ? user : null;
        }

        public void Register(string username, string password, string role)
        {
            if (_db.GetUser(username) == null)
            {
                _db.AddUser(new User { Username = username, Password = password, Role = role });
            }
        }
    }
}
