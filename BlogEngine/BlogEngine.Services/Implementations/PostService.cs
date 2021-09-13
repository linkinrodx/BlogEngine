using AutoMapper;
using BlogEngine.Data.Interfaces;
using BlogEngine.Services.Interfaces;
using BlogEngine.Services.Models;
using BlogEngine.Services.Util;
using System;
using System.Collections.Generic;

using DA = BlogEngine.Data.Models;

namespace BlogEngine.Services.Implementations
{
    public class PostService : IPostService
    {
        private readonly IMapper _mapper;
        private readonly IPostRepository _postRepository;
        private readonly ILogPostRepository _logPostRepository;

        public PostService(IMapper mapper,
            IPostRepository postRepository,
            ILogPostRepository logPostRepository)
        {
            _mapper = mapper;
            _postRepository = postRepository;
            _logPostRepository = logPostRepository;
        }

        public List<PostResult> GetPost(GetPostParameters parameters)
        {
            var resp = _postRepository.GetPost(parameters.Count);

            return _mapper.Map<List<PostResult>>(resp);
        }

        public List<PostResult> GetPostByAuthorId(GetPostByAuthorIdParameters parameters)
        {
            var resp = _postRepository.GetPostByAuthorId(parameters.AuthorId, parameters.Count);

            return _mapper.Map<List<PostResult>>(resp);
        }

        public List<PostResult> GetPostSubmmited(GetPostSubmmitedParameters parameters)
        {
            var resp = _postRepository.GetPostByPostStateId((byte)PostStateEnum.Submitted, parameters.Count);

            return _mapper.Map<List<PostResult>>(resp);
        }

        public PostResult AddPost(AddPostParameters parameters)
        {
            var post = _mapper.Map<DA.Post>(parameters);
            post.PostStateId = (byte)PostStateEnum.Created;
            var resp = _postRepository.AddPost(post);

            var postResult = _mapper.Map<PostResult>(resp);

            var logPost = _mapper.Map<DA.LogPost>(postResult);
            logPost.LogDate = DateTime.UtcNow;
            _logPostRepository.AddLogPost(logPost);

            return postResult;
        }

        public PostResult EditPost(EditPostParameters parameters)
        {
            var post = _postRepository.GetPostById(parameters.PostId);

            if (post == null)
                throw new Exception("Post not found");

            if (post.PostStateId != (byte)PostStateEnum.Submitted && post.PostStateId != (byte)PostStateEnum.Published)
                throw new Exception("Post cannot be edited");

            if (post.AuthorId != parameters.AuthorId)
                throw new Exception("You cannot edit the post");

            post.Title = parameters.Title;
            post.Content = parameters.Content;
            var resp = _postRepository.EditPost(post);

            return _mapper.Map<PostResult>(resp);
        }

        public PostResult SubmitPost(SubmitPostParameters parameters)
        {
            var post = _postRepository.GetPostById(parameters.PostId);

            if (post == null)
                throw new Exception("Post not found");

            if (!(post.PostStateId == (byte)PostStateEnum.Created || post.PostStateId == (byte)PostStateEnum.Rejected))
                throw new Exception("Post cannot be submited");

            if (post.AuthorId != parameters.AuthorId)
                throw new Exception("You cannot submit the post");

            post.PostStateId = (byte)PostStateEnum.Submitted;
            var resp = _postRepository.EditPost(post);

            var postResult = _mapper.Map<PostResult>(resp);

            var logPost = _mapper.Map<DA.LogPost>(postResult);
            logPost.LogDate = DateTime.UtcNow;
            _logPostRepository.AddLogPost(logPost);

            return _mapper.Map<PostResult>(resp);
        }

        public PostResult ApprovePost(ApprovePostParameters parameters)
        {
            var post = _postRepository.GetPostById(parameters.PostId);

            if (post == null)
                throw new Exception("Post not found");

            if (!(post.PostStateId == (byte)PostStateEnum.Submitted))
                throw new Exception("Post cannot be approved");

            post.PublishingDate = parameters.PublishingDate;
            post.PostStateId = (byte)PostStateEnum.Approved;
            var resp = _postRepository.EditPost(post);

            var postResult = _mapper.Map<PostResult>(resp);

            var logPost = _mapper.Map<DA.LogPost>(postResult);
            logPost.AuthorId = parameters.AuthorId;
            logPost.LogDate = DateTime.UtcNow;
            _logPostRepository.AddLogPost(logPost);

            return _mapper.Map<PostResult>(resp);
        }

        public PostResult RejectPost(RejectPostParameters parameters)
        {
            var post = _postRepository.GetPostById(parameters.PostId);

            if (post == null)
                throw new Exception("Post not found");

            if (!(post.PostStateId == (byte)PostStateEnum.Submitted))
                throw new Exception("Post cannot be rejected");

            post.PostStateId = (byte)PostStateEnum.Rejected;
            var resp = _postRepository.EditPost(post);

            var postResult = _mapper.Map<PostResult>(resp);

            var logPost = _mapper.Map<DA.LogPost>(postResult);
            logPost.AuthorId = parameters.AuthorId;
            logPost.LogDate = DateTime.UtcNow;
            logPost.Message = parameters.Message;
            _logPostRepository.AddLogPost(logPost);

            return _mapper.Map<PostResult>(resp);
        }
    }
}
