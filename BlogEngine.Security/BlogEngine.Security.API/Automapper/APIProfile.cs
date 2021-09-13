using AutoMapper;

using Service = BlogEngine.Security.Services.Models;
using Api = BlogEngine.Security.API.Models;

namespace BlogEngine.Security.API.Automapper
{
    public class APIProfile : Profile
    {
        public APIProfile()
        {
            // Service to API

            // API to Service
            CreateMap<Api.GetTokenRequest, Service.GetTokenParameters>();
        }
    }
}
