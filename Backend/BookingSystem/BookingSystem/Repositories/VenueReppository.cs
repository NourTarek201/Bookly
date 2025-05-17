using BookingSystem.Database;
using BookingSystem.Models.EventManagement;
using BookingSystem.Models.PlaceManagement;
using Microsoft.EntityFrameworkCore;

namespace BookingSystem.Repositories
{
    public class VenueRepository:BaseRepository<Venue>
    {
        public VenueRepository(DbBookingSystem context) : base(context)
        {
        }
        public async Task<Venue> getByName(string name)
        {
            return await dbSet.FirstOrDefaultAsync(x => x.Name == name);
        }
        public async Task<Venue> getExistVenue(Venue venue, Address address)
        {
            return await dbSet.FirstOrDefaultAsync(a => a.Name == venue.Name && a.Address==address);
        }
    }
}
