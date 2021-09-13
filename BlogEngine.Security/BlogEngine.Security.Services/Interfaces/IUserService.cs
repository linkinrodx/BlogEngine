using BlogEngine.Security.Services.Models;

namespace BlogEngine.Security.Services.Interfaces
{
    public interface IUserService
    {
        TokenResult GetToken(GetTokenParameters parameters);
    }
}
