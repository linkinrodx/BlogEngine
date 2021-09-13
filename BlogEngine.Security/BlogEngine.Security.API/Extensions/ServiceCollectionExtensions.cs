using BlogEngine.Security.API.Models;
using BlogEngine.Security.Data.Context;
using BlogEngine.Security.Data.Interfaces;
using BlogEngine.Security.Data.Repositories;
using BlogEngine.Security.Services.Implementations;
using BlogEngine.Security.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace BlogEngine.Security.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddDbContext<BlogEngineContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:BlogEngineDatabase"]));

            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUserService, UserService>();

            return services;
        }

        public static void AddCORS(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllCORS", builder =>
                {
                    builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
                    //.AllowCredentials();
                });
            });
        }

        public static void SetInvalidModel(this IServiceCollection services)
        {
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = context =>
                {
                    var response = new ResponseEntity<String>();
                    response.code = context.HttpContext.Response.StatusCode;
                    response.status = false;
                    response.message = "Contact the system administrator";
                    response.messageException = "Error 400: bad request";
                    response.result = null;

                    return new BadRequestObjectResult(response)
                    {
                        ContentTypes = { "application/problem+json" }
                    };
                };
            });
        }
    }
}
