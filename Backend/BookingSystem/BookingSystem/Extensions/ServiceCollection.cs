using BookingSystem.Database;
using BookingSystem.Models.Users;
using BookingSystem.Repositories;
using BookingSystem.Repositories.Interfaces;
using BookingSystem.services;
using BookingSystem.services.Authentication;
using BookingSystem.services.EventServices;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
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
                var jwt = configuration.GetSection("JwtSettings");
                var secretKey = jwt["SecretKey"];
                if (string.IsNullOrEmpty(secretKey))
                {
                    throw new ArgumentNullException(nameof(secretKey), "JWT SecretKey cannot be null or empty.");
                }
                options.Events = new JwtBearerEvents
                {
                    OnAuthenticationFailed = context =>
                    {
                        Console.WriteLine($"Token Error: {context.Exception.Message}");
                        return Task.CompletedTask;
                    },
                    OnTokenValidated = context =>
                    {
                        Console.WriteLine("Token Validated Successfully");
                        return Task.CompletedTask;
                    }
                };

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwt["Issuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
                };
            });

            return services;
        }

        public static IServiceCollection AddUserRole(this IServiceCollection services)
        {
            services.AddIdentity<BaseUser, IdentityRole<Guid>>().AddEntityFrameworkStores<DbBookingSystem>().AddDefaultTokenProviders();

            return services;
        }

        public static IServiceCollection AddScopedRepos(this IServiceCollection services)
        {
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<TagRepository>();
            services.AddScoped<VenueRepository>();
            services.AddScoped<CategoryRepository>();
            services.AddScoped<AddressRepository>();
            services.AddScoped<EventRepository>();
            services.AddScoped<BookedEventRepository>();
            return services;
        }

        public static IServiceCollection AddScopedServices(this IServiceCollection services)
        {
            services.AddScoped<JWTService>();
            services.AddScoped<AuthenService>();
            services.AddScoped<ValidationService>();
            services.AddScoped<EventService>();
            services.AddScoped<BookingService>();
            return services;
        }

        public static IServiceCollection AddSwaggerJWT(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSwaggerGen(c =>
            {
                c.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = Microsoft.OpenApi.Models.ParameterLocation.Header,
                    Description = "Enter your JWT token."
                });

                c.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
                {
                    {
                        new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                        {
                            Reference = new Microsoft.OpenApi.Models.OpenApiReference
                            {
                                Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] {}}}
                    );
                });

            return services;
        }

    }
}
