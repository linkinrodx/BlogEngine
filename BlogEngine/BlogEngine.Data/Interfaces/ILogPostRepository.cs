using BlogEngine.Data.Models;

namespace BlogEngine.Data.Interfaces
{
    public interface ILogPostRepository
    {
        LogPost AddLogPost(LogPost logPost);
    }
}
