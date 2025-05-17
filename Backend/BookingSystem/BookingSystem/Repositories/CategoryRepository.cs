using BookingSystem.Database;
using BookingSystem.Models.EventManagement;
using Microsoft.EntityFrameworkCore;

namespace BookingSystem.Repositories
{
    public class CategoryRepository:BaseRepository<Category>
    {
        public CategoryRepository(DbBookingSystem context) : base(context)
        {
        }
        public async Task<Category> getByName(string name)
        {
            return await dbSet.FirstOrDefaultAsync(x => x.Name == name);
        }
    }
}
