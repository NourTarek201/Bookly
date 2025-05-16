using BookingSystem.Models.EventManagement;

namespace BookingSystem.Models.Users
{
    public class Customer:BaseUser
    {
        public virtual List<BookedEvent> BookedEvents { get; set; } = new List<BookedEvent>();

    }
}
