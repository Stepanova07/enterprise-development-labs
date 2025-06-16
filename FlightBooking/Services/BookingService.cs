using FlightBooking.Data;
using FlightBooking.Domain.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightBooking.Domain.Services
{
    public class BookingService : IBookingService
    {
        private readonly IFlightRepository _flightRepository;
        private readonly IBookingRepository _bookingRepository;
        private readonly List<Customer> _customers;

        public BookingService(IFlightRepository flightRepository, IBookingRepository bookingRepository)
        {
            _flightRepository = flightRepository;
            _bookingRepository = bookingRepository;
            _customers = DataSeeder.SeedCustomers();
        }

        public async Task<IEnumerable<Flight>> GetAllAvailableFlightsAsync()
        {
            return await _flightRepository.GetAllFlightsAsync();
        }

        public async Task<IEnumerable<Flight>> SearchFlightsAsync(string departureCity, string arrivalCity, DateTime date)
        {
            return await _flightRepository.GetFlightsByRouteAsync(departureCity, arrivalCity, date);
        }

        public async Task<Flight> GetFlightDetailsAsync(int flightId)
        {
            var flights = await _flightRepository.GetAllFlightsAsync();
            return flights.FirstOrDefault(f => f.Id == flightId);
        }

        public async Task<IEnumerable<Customer>> GetFlightPassengersAsync(int flightId)
        {
            var bookings = await _bookingRepository.GetBookingsByFlightAsync(flightId);
            return bookings.Select(b => _customers.First(c => c.Id == b.Customer.Id))
                          .OrderBy(c => c.FullName);
        }

        public async Task<Booking> CreateBookingAsync(int flightId, int customerId, string ticketNumber)
        {
            var flight = await GetFlightDetailsAsync(flightId);
            var customer = _customers.FirstOrDefault(c => c.Id == customerId);

            if (flight == null || customer == null)
                return null;

            var booking = new Booking
            {
                Id = GenerateBookingId(),
                TicketNumber = ticketNumber,
                Flight = flight,
                Customer = customer
            };

            return await _bookingRepository.CreateBookingAsync(booking);
        }

        public async Task<bool> CancelBookingAsync(int bookingId)
        {
            return await _bookingRepository.DeleteBookingAsync(bookingId);
        }

        public async Task<Booking> GetBookingByIdAsync(int bookingId)
        {
            return (await _bookingRepository.GetAllBookingsAsync())
                .FirstOrDefault(b => b.Id == bookingId);
        }

        private int GenerateBookingId()
        {
            var bookings = _bookingRepository.GetAllBookingsAsync().Result;
            return bookings.Any() ? bookings.Max(b => b.Id) + 1 : 1;
        }
    }
}