using BlogEngine.Security.Data.Context;
using BlogEngine.Security.Data.Interfaces;
using BlogEngine.Security.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BlogEngine.Security.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly BlogEngineContext _blogEngineContext;

        public UserRepository(BlogEngineContext blogEngineContext)
        {
            _blogEngineContext = blogEngineContext;
        }

        public User LoginUser(string username, string password)
        {
            return _blogEngineContext.User.Where(o=> o.Username == username && o.Password == password).Include(o=> o.Role).FirstOrDefault();
        }
    }
}
