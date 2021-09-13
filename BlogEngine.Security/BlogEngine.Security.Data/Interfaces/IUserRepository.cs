using BlogEngine.Security.Data.Models;

namespace BlogEngine.Security.Data.Interfaces
{
    public interface IUserRepository
    {
        User LoginUser(string username, string password);
    }
}
