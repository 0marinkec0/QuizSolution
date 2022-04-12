using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Quiz.Application.Common.Interfaces;
using Quiz.Domain.Entites;
using Quiz.Interface.Data;
using Quiz.Interface.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Interface
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddIdentity<User, IdentityRole<int>>(o =>
            {
                o.Password.RequireDigit = false;
                o.Password.RequireLowercase = false;
                o.Password.RequireNonAlphanumeric = false;
                o.Password.RequiredLength = 3;
                o.Password.RequiredUniqueChars = 0;
                o.Password.RequireUppercase = false;
                o.User.RequireUniqueEmail = true;
                o.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+ ";
            })
                  .AddEntityFrameworkStores<QuizDbContext>()
                  .AddDefaultTokenProviders();

            services.AddDbContext<QuizDbContext>(options => 
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddTransient<IIdentityService, IdentityService>();

            return services;
        }
    }
}
