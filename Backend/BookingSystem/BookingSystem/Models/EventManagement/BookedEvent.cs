using BookingSystem.Models.Users;

namespace BookingSystem.Models.EventManagement
{
    public class BookedEvent:TimeEntity
    {
        public Guid EventId { get; set; }
        public virtual Event Event { get; set; }


        public Guid CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

    }
}
