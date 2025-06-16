using FlightBooking.Data;
using FlightBooking.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightBooking.Domain.Services.InMemory
{
    public class FlightRepository : IFlightRepository
    {
        private readonly List<Flight> _flights;

        public FlightRepository()
        {
            _flights = DataSeeder.SeedFlights();
        }

        public Task<IEnumerable<Flight>> GetAllFlightsAsync()
        {
            return Task.FromResult(_flights.AsEnumerable());
        }

        public Task<IEnumerable<Flight>> GetFlightsByRouteAsync(string departureCity, string arrivalCity, DateTime date)
        {
            var result = _flights.Where(f =>
                f.DepartureCity == departureCity &&
                f.ArrivalCity == arrivalCity &&
                f.DepartureTime.Date == date.Date);

            return Task.FromResult(result);
        }
    }
}