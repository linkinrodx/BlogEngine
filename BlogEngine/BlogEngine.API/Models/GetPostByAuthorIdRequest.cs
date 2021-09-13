using System.ComponentModel.DataAnnotations;

namespace BlogEngine.API.Models
{
    public class GetPostByAuthorIdRequest
    {
        public int Count { get; set; } = 10;
    }
}
