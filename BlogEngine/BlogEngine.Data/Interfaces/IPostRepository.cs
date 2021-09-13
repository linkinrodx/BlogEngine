using BlogEngine.Data.Models;
using System.Collections.Generic;

namespace BlogEngine.Data.Interfaces
{
    public interface IPostRepository
    {
        List<Post> GetPost(int count);

        List<Post> GetPostByAuthorId(int authorId, int count);

        List<Post> GetPostByPostStateId(int postStateId, int count);

        Post GetPostById(int postId);

        Post AddPost(Post post);

        Post EditPost(Post post);
    }
}
