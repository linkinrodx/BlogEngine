using AutoMapper;
using BlogEngine.API.Configuration;
using BlogEngine.API.Models;
using BlogEngine.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Service = BlogEngine.Services.Models;

namespace BlogEngine.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICommentService _commentService;

        public CommentController(IMapper mapper,
            ICommentService commentService)
        {
            _mapper = mapper;
            _commentService = commentService;
        }

        [HttpPost]
        [AuthorizeRoles(Role.Public, Role.Writer, Role.Editor)]
        public ActionResult AddComment([FromBody] AddCommentRequest request)
        {
            var parameters = _mapper.Map<Service.AddCommentParameters>(request);

            var result = _commentService.AddComment(parameters);

            return Ok(_mapper.Map<CommentResponse>(result));
        }
    }
}
