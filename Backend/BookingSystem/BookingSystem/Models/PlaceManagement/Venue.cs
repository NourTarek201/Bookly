using BookingSystem.Models.EventManagement;

namespace BookingSystem.Models.PlaceManagement
{
    public class Venue : BaseEntity
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }


        public Guid AddressId { get; set; }
        public virtual Address Address { get; set; }

        public virtual List<Event> Events { get; set; } = new List<Event>();
    }
}
