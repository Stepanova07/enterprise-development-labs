using FlightBooking.Domain.Models;
using System;
using System.Collections.Generic;

namespace FlightBooking.Data
{
    public static class DataSeeder
    {
        public static List<Flight> SeedFlights()
        {
            return new List<Flight>
            {
                new Flight {
                    Id = 1,
                    FlightNumber = "SU100",
                    DepartureCity = "Moscow",
                    ArrivalCity = "London",
                    AircraftType = AircraftType.Boeing737,
                    DepartureTime = DateTime.Now.AddDays(1),
                    ArrivalTime = DateTime.Now.AddDays(1).AddHours(4)
                },
                new Flight {
                    Id = 2,
                    FlightNumber = "SU200",
                    DepartureCity = "London",
                    ArrivalCity = "New York",
                    AircraftType = AircraftType.Boeing787,
                    DepartureTime = DateTime.Now.AddDays(2),
                    ArrivalTime = DateTime.Now.AddDays(2).AddHours(8)
                }
            };
        }

        public static List<Customer> SeedCustomers()
        {
            return new List<Customer>
            {
                new Customer {
                    Id = 1,
                    PassportNumber = "123456789",
                    FullName = "Ivanov Ivan",
                    BirthDate = new DateTime(1980, 5, 15)
                },
                new Customer {
                    Id = 2,
                    PassportNumber = "987654321",
                    FullName = "Petrova Maria",
                    BirthDate = new DateTime(1990, 8, 22)
                }
            };
        }

        public static List<Booking> SeedBookings(List<Flight> flights, List<Customer> customers)
        {
            return new List<Booking>
            {
                new Booking {
                    Id = 1,
                    TicketNumber = "TK1001",
                    Flight = flights[0],
                    Customer = customers[0]
                },
                new Booking {
                    Id = 2,
                    TicketNumber = "TK1002",
                    Flight = flights[0],
                    Customer = customers[1]
                }
            };
        }

        internal static List<Booking>? SeedBookings()
        {
            throw new NotImplementedException();
        }
    }
}
