using AutoMapper;
using BlogEngine.API.Configuration;
using BlogEngine.API.Models;
using BlogEngine.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Service = BlogEngine.Services.Models;

namespace BlogEngine.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IPostService _postService;

        public PostController(IMapper mapper,
            IPostService postService)
        {
            _mapper = mapper;
            _postService = postService;
        }

        #region Role Public

        [HttpGet]
        [AuthorizeRoles(Role.Public, Role.Writer, Role.Editor)]
        public ActionResult GetListPost([FromQuery] GetPostRequest request)
        {
            var parameters = _mapper.Map<Service.GetPostParameters>(request);

            var result = _postService.GetPost(parameters);

            return Ok(new
            {
                Result = _mapper.Map<List<PostResponse>>(result)
            });
        }

        #endregion

        #region Role Writer

        [HttpGet]
        [AuthorizeRoles(Role.Writer)]
        public ActionResult GetListPostByAuthorId([FromQuery] GetPostByAuthorIdRequest request)
        {
            var userId = User.FindFirst("userId").Value;

            var parameters = _mapper.Map<Service.GetPostByAuthorIdParameters>(request);
            parameters.AuthorId = Convert.ToInt32(userId);

            var result = _postService.GetPostByAuthorId(parameters);

            return Ok(new
            {
                Result = _mapper.Map<List<PostByAuthorIdResponse>>(result)
            });
        }

        [HttpPost]
        [AuthorizeRoles(Role.Writer)]
        public ActionResult AddPost([FromBody] AddPostRequest request)
        {
            var userId = User.FindFirst("userId").Value;

            var parameters = _mapper.Map<Service.AddPostParameters>(request);
            parameters.AuthorId = Convert.ToInt32(userId);

            var result = _postService.AddPost(parameters);

            return Ok(_mapper.Map<PostResponse>(result));
        }

        [HttpPut]
        [AuthorizeRoles(Role.Writer)]
        public ActionResult EditPost([FromBody] EditPostRequest request)
        {
            var userId = User.FindFirst("userId").Value;

            var parameters = _mapper.Map<Service.EditPostParameters>(request);
            parameters.AuthorId = Convert.ToInt32(userId);

            var result = _postService.EditPost(parameters);

            return Ok(_mapper.Map<PostResponse>(result));
        }

        [HttpPut]
        [AuthorizeRoles(Role.Writer)]
        public ActionResult SubmitPost([FromBody] SubmitPostRequest request)
        {
            var userId = User.FindFirst("userId").Value;

            var parameters = _mapper.Map<Service.SubmitPostParameters>(request);
            parameters.AuthorId = Convert.ToInt32(userId);

            var result = _postService.SubmitPost(parameters);

            return Ok(_mapper.Map<PostResponse>(result));
        }

        #endregion

        #region Role Editor

        [HttpGet]
        [AuthorizeRoles(Role.Editor)]
        public ActionResult GetListPostSubmmited([FromQuery] GetPostSubmmitedRequest request)
        {
            var parameters = _mapper.Map<Service.GetPostSubmmitedParameters>(request);

            var result = _postService.GetPostSubmmited(parameters);

            return Ok(new
            {
                Result = _mapper.Map<List<PostResponse>>(result)
            });
        }

        [HttpPut]
        [AuthorizeRoles(Role.Editor)]
        public ActionResult ApprovePost([FromBody] ApprovePostRequest request)
        {
            var userId = User.FindFirst("userId").Value;

            var parameters = _mapper.Map<Service.ApprovePostParameters>(request);
            parameters.AuthorId = Convert.ToInt32(userId);

            var result = _postService.ApprovePost(parameters);

            return Ok(_mapper.Map<PostResponse>(result));
        }

        [HttpPut]
        [AuthorizeRoles(Role.Editor)]
        public ActionResult RejectPost([FromBody] RejectPostRequest request)
        {
            var userId = User.FindFirst("userId").Value;

            var parameters = _mapper.Map<Service.RejectPostParameters>(request);
            parameters.AuthorId = Convert.ToInt32(userId);

            var result = _postService.RejectPost(parameters);

            return Ok(_mapper.Map<PostResponse>(result));
        }

        #endregion
    }
}
