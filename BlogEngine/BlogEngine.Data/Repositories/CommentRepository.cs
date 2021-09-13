using BlogEngine.Data.Context;
using BlogEngine.Data.Interfaces;
using BlogEngine.Data.Models;

namespace BlogEngine.Data.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly BlogEngineContext _blogEngineContext;

        public CommentRepository(BlogEngineContext blogEngineContext)
        {
            _blogEngineContext = blogEngineContext;
        }

        public Comment AddComment(Comment comment)
        {
            _blogEngineContext.Comment.Add(comment);
            _blogEngineContext.SaveChanges();

            return comment;
        }
    }
}
