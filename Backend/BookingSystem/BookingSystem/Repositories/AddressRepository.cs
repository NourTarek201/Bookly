using BookingSystem.Database;
using BookingSystem.Models.PlaceManagement;
using Microsoft.EntityFrameworkCore;

namespace BookingSystem.Repositories
{
    public class AddressRepository : BaseRepository<Address>
    {
        public AddressRepository(DbBookingSystem context) : base(context)
        {
        }
        public async Task<Address> getExistAddress(Address address)
        {
            return await dbSet.FirstOrDefaultAsync(a =>a.buildingNo == address.buildingNo && a.Street == address.Street &&
            a.City == address.City && a.Country == address.Country);
        }
    }
}
