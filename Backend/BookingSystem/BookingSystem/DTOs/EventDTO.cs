namespace BookingSystem.DTOs
{
    public class EventDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; }
        public string CategoryName { get; set; }
        public string VenueName { get; set; }
        public string VenuePhone { get; set; }
        public AddressDTO Address { get; set; }
        public TagDTO? Tags { get; set; }
    }
}
