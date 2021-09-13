using AutoMapper;
using System.Linq;

using Service = BlogEngine.Services.Models;
using DA = BlogEngine.Data.Models;

namespace BlogEngine.Services.Automapper
{
    public class ServiceProfile : Profile
    {
        public ServiceProfile()
        {
            //DA to Service
            CreateMap<DA.Post, Service.PostResult>()
                .ForPath(dist => dist.Message, opt => opt.MapFrom(src => src.LogPost.OrderBy(o=> o.PostId).LastOrDefault().Message));
            CreateMap<DA.Comment, Service.CommentResult>();

            //Service to DA
            CreateMap<Service.AddCommentParameters, DA.Comment>();
            CreateMap<Service.AddPostParameters, DA.Post>();
            CreateMap<Service.PostResult, DA.LogPost>();
        }
    }
}
