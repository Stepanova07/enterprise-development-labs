// Services/IBookingRepository.cs
using FlightBooking.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlightBooking.Domain.Services
{
    public interface IBookingRepository
    {
        Task<IEnumerable<Booking>> GetAllBookingsAsync();
        Task<IEnumerable<Booking>> GetBookingsByFlightAsync(int flightId);
        Task<Booking> CreateBookingAsync(Booking booking);
        Task<bool> DeleteBookingAsync(int bookingId);
    }
}