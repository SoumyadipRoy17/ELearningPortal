using ElearningPortal.Models;

namespace ElearningPortal.Services
{
    public interface IAuthService
    {
        User Login(string username, string password);
        void Register(string username, string password, string role);
    }
}
