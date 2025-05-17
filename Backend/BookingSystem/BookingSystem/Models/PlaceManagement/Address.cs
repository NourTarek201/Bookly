using BookingSystem.Models.Users;

namespace BookingSystem.Models.PlaceManagement
{
    public class Address:BaseEntity
    {
        public string? buildingNo { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Country { get; set; }


        public virtual Venue? Venue { get; set; }
        public virtual BaseUser? BaseUser { get; set; }
    }
}
