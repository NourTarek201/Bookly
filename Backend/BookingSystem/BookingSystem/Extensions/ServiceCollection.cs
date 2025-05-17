using BookingSystem.Database;
using Microsoft.EntityFrameworkCore;

namespace BookingSystem.Extensions
{
    public static class ServiceCollections
    {
        public static IServiceCollection AddBookingSystemDb(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DbBookingSystem>(options =>
                options.UseSqlServer(configuration.GetConnectionString("Local")));
            return services;
        }
    }
}
