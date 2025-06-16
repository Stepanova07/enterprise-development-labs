// Services/InMemory/BookingRepository.cs
using FlightBooking.Data;
using FlightBooking.Domain.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightBooking.Domain.Services.InMemory
{
    public class BookingRepository : IBookingRepository
    {
        private readonly List<Booking> _bookings;

        public BookingRepository()
        {
            _bookings = DataSeeder.SeedBookings();
        }

        public Task<IEnumerable<Booking>> GetAllBookingsAsync()
        {
            return Task.FromResult(_bookings.AsEnumerable());
        }

        public Task<IEnumerable<Booking>> GetBookingsByFlightAsync(int flightId)
        {
            var result = _bookings.Where(b => b.Flight.Id == flightId);
            return Task.FromResult(result);
        }

        public Task<Booking> CreateBookingAsync(Booking booking)
        {
            _bookings.Add(booking);
            return Task.FromResult(booking);
        }

        public Task<bool> DeleteBookingAsync(int bookingId)
        {
            var booking = _bookings.FirstOrDefault(b => b.Id == bookingId);
            if (booking != null)
            {
                _bookings.Remove(booking);
                return Task.FromResult(true);
            }
            return Task.FromResult(false);
        }
    }
}