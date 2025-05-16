using BookingSystem.Models.Users;

namespace BookingSystem.Models.EventManagement
{
    public class BookedEvent : ITime
    {
        public Guid EventId { get; set; }
        public virtual Event Event { get; set; }


        public Guid CustomerId { get; set; }
        public virtual Customer Customer { get; set; }


        //time interface
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    }
}
