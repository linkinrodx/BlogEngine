using BlogEngine.API.Models;
using BlogEngine.Data.Interfaces;
using BlogEngine.Data.Repositories;
using BlogEngine.Data.Context;
using BlogEngine.Services.Implementations;
using BlogEngine.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

namespace BlogEngine.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddDbContext<BlogEngineContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:BlogEngineDatabase"]));

            services.AddTransient<IPostRepository, PostRepository>();
            services.AddTransient<IPostService, PostService>();
            services.AddTransient<ICommentRepository, CommentRepository>();
            services.AddTransient<ICommentService, CommentService>();
            services.AddTransient<ILogPostRepository, LogPostRepository>();

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

        public static void AddAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = configuration["JWT:Issuer"],
                        ValidAudience = configuration["JWT:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(configuration["JWT:SecretKey"])
                        )
                    };
                });
        }
    }
}
