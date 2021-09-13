using BlogEngine.Data.Interfaces;
using BlogEngine.Data.Context;
using BlogEngine.Data.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BlogEngine.Data.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly BlogEngineContext _blogEngineContext;

        public PostRepository(BlogEngineContext blogEngineContext)
        {
            _blogEngineContext = blogEngineContext;
        }

        public List<Post> GetPost(int count)
        {
            return _blogEngineContext.Post.OrderByDescending(o=> o.PostId).Take(count).ToList();
        }

        public List<Post> GetPostByAuthorId(int authorId, int count)
        {
            return _blogEngineContext.Post.Where(o=> o.AuthorId == authorId).OrderByDescending(o => o.PostId).Take(count).Include(o=> o.LogPost).ToList();
        }

        public List<Post> GetPostByPostStateId(int postStateId, int count)
        {
            return _blogEngineContext.Post.Where(o => o.PostStateId == postStateId).OrderByDescending(o => o.PostId).Take(count).ToList();
        }

        public Post GetPostById(int postId)
        {
            return _blogEngineContext.Post.Where(o => o.PostId == postId).FirstOrDefault();
        }

        public Post AddPost(Post post)
        {
            _blogEngineContext.Post.Add(post);
            _blogEngineContext.SaveChanges();

            return post;
        }

        public Post EditPost(Post post)
        {
            _blogEngineContext.Post.Update(post);
            _blogEngineContext.SaveChanges();

            return post;
        }
    }
}
