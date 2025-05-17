using BookingSystem.Database;
using Microsoft.EntityFrameworkCore;

namespace BookingSystem.Repositories
{
    public class BookedEventRepository
    {
        private readonly DbBookingSystem context;
        public BookedEventRepository(DbBookingSystem context)
        {
            this.context = context;
        }
        public async Task<bool> isBooked(Guid eventId, Guid userId)
        {
            return await context.BookedEvents.AnyAsync(x => x.EventId == eventId && x.CustomerId == userId);
        }
    }
}
