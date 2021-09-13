using BlogEngine.Services.Models;

namespace BlogEngine.Services.Interfaces
{
    public interface ICommentService
    {
        CommentResult AddComment(AddCommentParameters parameters);
    }
}
