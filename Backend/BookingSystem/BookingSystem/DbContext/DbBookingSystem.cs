using Microsoft.EntityFrameworkCore;
using BookingSystem.Models;
using BookingSystem.Models.EventManagement;
using BookingSystem.Models.PlaceManagement;
using BookingSystem.Models.Users;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Reflection.Emit;
namespace BookingSystem.Database
{
    public class DbBookingSystem : IdentityDbContext<BaseUser, IdentityRole<Guid>, Guid>
    {
        public DbBookingSystem(DbContextOptions<DbBookingSystem> options): base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DbBookingSystem).Assembly);
        }

        //event management
        public DbSet<Event> Events { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<BookedEvent> BookedEvents { get; set; }
        public DbSet<EventTag> EventTags { get; set; }
        public DbSet<Tag>Tags { get; set; }


        //place management
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Venue> Venues { get; set; }

        //users
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Customer> Customers { get; set; }

    }
}
