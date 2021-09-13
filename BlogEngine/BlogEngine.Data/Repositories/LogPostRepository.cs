using BlogEngine.Data.Interfaces;
using BlogEngine.Data.Context;
using BlogEngine.Data.Models;

namespace BlogEngine.Data.Repositories
{
    public class LogPostRepository : ILogPostRepository
    {
        private readonly BlogEngineContext _blogEngineContext;

        public LogPostRepository(BlogEngineContext blogEngineContext)
        {
            _blogEngineContext = blogEngineContext;
        }

        public LogPost AddLogPost(LogPost logPost)
        {
            _blogEngineContext.LogPost.Add(logPost);
            _blogEngineContext.SaveChanges();

            return logPost;
        }
    }
}
