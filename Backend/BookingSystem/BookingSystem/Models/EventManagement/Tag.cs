namespace BookingSystem.Models.EventManagement
{
    public class Tag:BaseEntity
    {
        public string Name { get; set; }
        public virtual List<EventTag> EventTags { get; set; } = new List<EventTag>();
    }
}
