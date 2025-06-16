// Services/IBookingService.cs
using FlightBooking.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlightBooking.Domain.Services
{
    public interface IBookingService
    {
        Task<IEnumerable<Flight>> GetAllAvailableFlightsAsync();
        Task<IEnumerable<Flight>> SearchFlightsAsync(string departureCity, string arrivalCity, DateTime date);
        Task<Flight> GetFlightDetailsAsync(int flightId);
        Task<IEnumerable<Customer>> GetFlightPassengersAsync(int flightId);
        Task<Booking> CreateBookingAsync(int flightId, int customerId, string ticketNumber);
        Task<bool> CancelBookingAsync(int bookingId);
        Task<Booking> GetBookingByIdAsync(int bookingId);
    }
}