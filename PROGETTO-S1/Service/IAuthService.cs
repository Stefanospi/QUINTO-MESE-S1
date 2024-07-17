using PROGETTO_S1.Models;

namespace PROGETTO_S1.Service
{
    public interface IAuthService
    {
        Users Login(string username, string password);
        Users Register(string username, string password);

    }
}
