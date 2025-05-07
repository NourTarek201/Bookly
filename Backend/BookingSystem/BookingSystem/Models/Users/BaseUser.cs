using BookingSystem.Models.PlaceManagement;

namespace BookingSystem.Models.Users
{
    public class BaseUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string phoneNumber { get; set; }
        public DateOnly dateOfBirth { get; set; }

        
        public Guid AddressId { get; set; }
        public virtual Address Address { get; set; }
    }
}
