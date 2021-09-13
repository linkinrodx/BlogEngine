using AutoMapper;
using BlogEngine.Data.Interfaces;
using BlogEngine.Services.Interfaces;
using BlogEngine.Services.Models;
using BlogEngine.Services.Util;

using DA = BlogEngine.Data.Models;

namespace BlogEngine.Services.Implementations
{
    public class CommentService : ICommentService
    {
        private readonly IMapper _mapper;
        private readonly ICommentRepository _commentRepository;

        public CommentService(IMapper mapper,
            ICommentRepository commentRepository)
        {
            _mapper = mapper;
            _commentRepository = commentRepository;
        }

        public CommentResult AddComment(AddCommentParameters parameters)
        {
            var comment = _mapper.Map<DA.Comment>(parameters);
            comment.State = (byte)StateEnum.Active;

            var resp = _commentRepository.AddComment(comment);

            return _mapper.Map<CommentResult>(resp);
        }
    }
}
