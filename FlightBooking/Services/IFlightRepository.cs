using FlightBooking.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlightBooking.Domain.Services
{
    public interface IFlightRepository
    {
        Task<IEnumerable<Flight>> GetAllFlightsAsync();
        Task<IEnumerable<Flight>> GetFlightsByRouteAsync(string departureCity, string arrivalCity, DateTime date);
    }
}