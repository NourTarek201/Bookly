using BookingSystem.Models.PlaceManagement;

namespace BookingSystem.DTOs
{
    public class RegisterationDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public DateOnly dateOfBirth { get; set; }
        public AddressDTO? Address { get; set; }
    }
}
