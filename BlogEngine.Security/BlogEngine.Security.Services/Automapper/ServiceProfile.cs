using AutoMapper;

using Service = BlogEngine.Security.Services.Models;
using DA = BlogEngine.Security.Data.Models;

namespace BlogEngine.Security.Services.Automapper
{
    public class ServiceProfile : Profile
    {
        public ServiceProfile()
        {
            //DA to Service
            CreateMap<DA.User, Service.UserResult>();
            CreateMap<DA.Role, Service.RoleResult>();

            //Service to DA
        }
    }
}
