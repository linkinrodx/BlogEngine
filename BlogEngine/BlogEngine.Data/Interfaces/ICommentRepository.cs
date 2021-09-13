using BlogEngine.Data.Models;

namespace BlogEngine.Data.Interfaces
{
    public interface ICommentRepository
    {
        Comment AddComment(Comment comment);
    }
}
