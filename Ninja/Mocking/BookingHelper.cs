using Ninja.Mocking.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ninja.Mocking
{
    public static class BookingHelper
    {
        public static string OverlappingBookingExist(Booking booking, IBookingRepository bookingRepository)
        {
            if (booking.Status == "Cancelled")
                return string.Empty;

            var bookings = bookingRepository.GetActiveBookings(booking.Id);

            //bool overlap = tStartA < tEndB && tStartB < tEndA;
            var overlappingBooking = bookings.FirstOrDefault(b =>
                                                                  booking.ArrivalDate < b.DepartureDate &&
                                                                  b.ArrivalDate < booking.DepartureDate);

            return overlappingBooking == null ? string.Empty : overlappingBooking.Reference;
        }
    }




}
