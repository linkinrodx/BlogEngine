using System.ComponentModel.DataAnnotations;

namespace BlogEngine.Security.API.Models
{
    public class GetTokenRequest
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
