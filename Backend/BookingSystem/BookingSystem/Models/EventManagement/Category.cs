namespace BookingSystem.Models.EventManagement
{
    public class Category:BaseEntity
    {
        public string Name { get; set; }
        public virtual List<Event> Events { get; set; } = new List<Event>();
    }
}
