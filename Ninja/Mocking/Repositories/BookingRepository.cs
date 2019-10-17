using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ninja.Mocking.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        public IQueryable<Booking> GetActiveBookings(int? bookingId = null)
        {
            var unitOfWork = new UnitOfWork();
            var bookings = unitOfWork.Query<Booking>()
                          .Where(b => (b.Id != bookingId || bookingId == null) && b.Status != "Cancelled");

            return bookings;
        }
    }
}
