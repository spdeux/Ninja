using System.Linq;

namespace Ninja.Mocking.Repositories
{
    public interface IBookingRepository
    {
        IQueryable<Booking> GetActiveBookings(int? bookingId = null);
    }
}