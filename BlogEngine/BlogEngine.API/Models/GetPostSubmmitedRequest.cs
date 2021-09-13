using System.ComponentModel.DataAnnotations;

namespace BlogEngine.API.Models
{
    public class GetPostSubmmitedRequest
    {
        public int Count { get; set; } = 10;
    }
}
