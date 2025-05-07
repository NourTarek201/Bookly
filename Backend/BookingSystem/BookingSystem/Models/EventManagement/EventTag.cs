
namespace BookingSystem.Models.EventManagement
{
    public class EventTag
    {
        public Guid EventId { get; set; }
        public virtual Event Event { get; set; }


        public Guid TagId { get; set; }
        public virtual Tag Tag { get; set; }
    }
}
