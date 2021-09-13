using System.ComponentModel.DataAnnotations;

namespace BlogEngine.API.Models
{
    public class RejectPostRequest
    {
        [Required]
        public int PostId { get; set; }

        [Required]
        public string Message { get; set; }
    }
}
