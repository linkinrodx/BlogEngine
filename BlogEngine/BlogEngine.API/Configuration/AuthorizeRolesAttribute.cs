using Microsoft.AspNetCore.Authorization;

namespace BlogEngine.API.Configuration
{
    public static class Role
    {
        public const string Public = "Public";
        public const string Writer = "Writer";
        public const string Editor = "Editor";
    }

    public class AuthorizeRolesAttribute : AuthorizeAttribute
    {
        public AuthorizeRolesAttribute(params string[] roles) : base()
        {
            Roles = string.Join(",", roles);
        }
    }
}
