using BookingSystem.Models.PlaceManagement;
using Microsoft.AspNetCore.Identity;

namespace BookingSystem.Models.Users
{
    public class BaseUser : IdentityUser<Guid>, ITime
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly dateOfBirth { get; set; }

        
        public Guid AddressId { get; set; }
        public virtual Address Address { get; set; }

        //from time interface 
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
