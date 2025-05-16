using BookingSystem.Models.EventManagement;
using System.Text.Json.Serialization;

namespace BookingSystem.Models.Users
{
    public class Admin:BaseUser
    {
        public virtual List<Event> Events { get; set; } = new List<Event>();
    }
}
