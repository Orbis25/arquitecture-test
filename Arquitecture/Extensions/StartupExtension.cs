using AutoMapper;
using BussinesLayer.Auth;
using BussinesLayer.Interfaces.Task;
using BussinesLayer.Services.Task;
using DataLayer.Mapping;
using DataLayer.Options;
using DataLayer.Persistence;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arquitecture.Extensions
{
    public static class StartupExtension
    {
        public static void ImplementDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.Configure<SwaggerOption>(configuration.GetSection(nameof(SwaggerOption)));
            services.Configure<JwtOption>(configuration.GetSection(nameof(JwtOption)));

        }

        public static void ImplementServices(this IServiceCollection services)
        {
            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<ITaskService, TaskService>();
        }

        public static void ImplementDocApi(this IServiceCollection services, IConfiguration configuration)
        {
            var options = configuration.GetSection(nameof(SwaggerOption));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(options[nameof(SwaggerOption.Version)],
                    new OpenApiInfo { Title = options[nameof(SwaggerOption.Title)], Version = options[nameof(SwaggerOption.Version)] });
            });
        }

        public static void ImplementJwt(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
             .AddJwtBearer(options =>
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = configuration.GetSection(nameof(JwtOption))[nameof(JwtOption.ValidIssuer)],
                ValidAudience = configuration.GetSection(nameof(JwtOption))[nameof(JwtOption.ValidAudience)],
                IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(configuration.GetSection(nameof(JwtOption))[nameof(JwtOption.SecretKey)])),
                ClockSkew = TimeSpan.FromMinutes(2)
            });
        }

        public static void ImplementAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(SharedMap));
        }

    }
}
