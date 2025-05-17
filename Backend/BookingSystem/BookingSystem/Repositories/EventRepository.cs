using BookingSystem.Database;
using BookingSystem.Models.EventManagement;
using Microsoft.EntityFrameworkCore;

namespace BookingSystem.Repositories
{
    public class EventRepository : BaseRepository<Event>
    {
        public EventRepository(DbBookingSystem context) : base(context)
        {
        }
        public override async Task<IEnumerable<Event>> getAll()
        {
            return await dbSet.Include(v=>v.Venue).ThenInclude(vad=>vad.Address)
                .Include(c=>c.Category).Include(t=>t.EventTags)
                .ThenInclude(et => et.Tag).ToListAsync();
        }
    }
}
