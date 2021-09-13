using AutoMapper;

using Service = BlogEngine.Services.Models;
using Api = BlogEngine.API.Models;

namespace BlogEngine.API.Automapper
{
    public class APIProfile : Profile
    {
        public APIProfile()
        {
            // Service to API
            CreateMap<Service.PostResult, Api.PostResponse>();
            CreateMap<Service.PostResult, Api.PostByAuthorIdResponse>();
            CreateMap<Service.CommentResult, Api.CommentResponse>();

            // API to Service
            CreateMap<Api.GetPostRequest, Service.GetPostParameters>();
            CreateMap<Api.GetPostByAuthorIdRequest, Service.GetPostByAuthorIdParameters>();
            CreateMap<Api.GetPostSubmmitedRequest, Service.GetPostSubmmitedParameters>();
            CreateMap<Api.AddCommentRequest, Service.AddCommentParameters>();
            CreateMap<Api.AddPostRequest, Service.AddPostParameters>();
            CreateMap<Api.EditPostRequest, Service.EditPostParameters>();
            CreateMap<Api.SubmitPostRequest, Service.SubmitPostParameters>();
            CreateMap<Api.ApprovePostRequest, Service.ApprovePostParameters>();
            CreateMap<Api.RejectPostRequest, Service.RejectPostParameters>();
        }
    }
}
