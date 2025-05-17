using BookingSystem.Database;
using BookingSystem.Models.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

namespace BookingSystem.Extensions
{
    public static class ServiceCollection
    {
        public static IServiceCollection AddBookingSystemDb(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DbBookingSystem>(options =>
                options.UseSqlServer(configuration.GetConnectionString("Local")));
            return services;
        }

        public static IServiceCollection AddAuthenJWT(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication("Bearer").AddJwtBearer("Bearer", options =>
            {
                var jwt = configuration.GetSection("Jwt");
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwt["Issuer"],
                    ValidAudience = jwt["Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt["Key"]))
                };
            });
            return services;
        }

        public static IServiceCollection AddUserRole(this IServiceCollection services)
        {
            services.AddIdentity<BaseUser, IdentityRole>().AddEntityFrameworkStores<DbBookingSystem>().AddDefaultTokenProviders();

            return services;
        }
    }
}
