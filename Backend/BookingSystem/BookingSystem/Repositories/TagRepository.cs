using BookingSystem.Database;
using BookingSystem.Models.EventManagement;
using BookingSystem.Models.PlaceManagement;
using Microsoft.EntityFrameworkCore;

namespace BookingSystem.Repositories
{
    public class TagRepository: BaseRepository<Tag>
    {
        public TagRepository(DbBookingSystem context) : base(context)
        {
        }
        public async Task<Tag> getByName(string name)
        {
            return await dbSet.FirstOrDefaultAsync(x => x.Name == name);
        }

        public async Task<bool> isTagExists(Tag Tag)
        {
            return await dbSet.AnyAsync(a =>a.Name == Tag.Name);
        }
    }
}
