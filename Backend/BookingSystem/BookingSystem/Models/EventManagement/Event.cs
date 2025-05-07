using BookingSystem.Models.PlaceManagement;
using BookingSystem.Models.Users;

namespace BookingSystem.Models.EventManagement
{
    public class Event : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; }


        public Guid AdminId { get; set; }
        public virtual Admin Admin { get; set; }

        public Guid CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public Guid VenueId { get; set; }
        public virtual Venue Venue { get; set; }

        public virtual List<BookedEvent> BookedEvents { get; set; } = new List<BookedEvent>();

        public virtual List<EventTag> EventTags { get; set; } = new List<EventTag>();


    }
}
