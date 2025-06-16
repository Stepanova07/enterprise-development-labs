using FlightBooking.Data;
using FlightBooking.Domain.Models;
using FlightBooking.Domain.Services;
using FlightBooking.Domain.Services.InMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace FlightBooking.Tests
{
    // Тесты для DataSeeder
    public class DataSeederTests
    {
        [Fact]
        public void SeedFlights_ReturnsCorrectNumberOfFlights()
        {
            // Arrange & Act
            var flights = DataSeeder.SeedFlights();

            // Assert
            Assert.Equal(2, flights.Count);
        }

        [Fact]
        public void SeedCustomers_ReturnsCorrectNumberOfCustomers()
        {
            // Arrange & Act
            var customers = DataSeeder.SeedCustomers();

            // Assert
            Assert.Equal(2, customers.Count);
        }

        [Fact]
        public void SeedBookings_ReturnsCorrectNumberOfBookings()
        {
            // Arrange
            var flights = DataSeeder.SeedFlights();
            var customers = DataSeeder.SeedCustomers();

            // Act
            var bookings = DataSeeder.SeedBookings(flights, customers);

            // Assert
            Assert.Equal(2, bookings.Count);
        }
    }

    // Тесты для модели Booking
    public class BookingModelTests
    {
        [Fact]
        public void Booking_Properties_WorkCorrectly()
        {
            // Arrange
            var flight = new Flight { Id = 1 };
            var customer = new Customer { Id = 1 };

            // Act
            var booking = new Booking
            {
                Id = 1,
                TicketNumber = "TK1001",
                Flight = flight,
                Customer = customer
            };

            // Assert
            Assert.Equal(1, booking.Id);
            Assert.Equal("TK1001", booking.TicketNumber);
            Assert.Equal(flight, booking.Flight);
            Assert.Equal(customer, booking.Customer);
        }

        [Fact]
        public void Booking_DefaultValues_AreSet()
        {
            // Arrange & Act
            var booking = new Booking();

            // Assert
            Assert.Equal(string.Empty, booking.TicketNumber);
            Assert.Null(booking.Flight);
            Assert.Null(booking.Customer);
        }
    }

    // Тесты для модели Customer
    public class CustomerModelTests
    {
        [Fact]
        public void Customer_Properties_WorkCorrectly()
        {
            // Arrange & Act
            var customer = new Customer
            {
                Id = 1,
                PassportNumber = "123456789",
                FullName = "Ivanov Ivan",
                BirthDate = new DateTime(1980, 5, 15)
            };

            // Assert
            Assert.Equal(1, customer.Id);
            Assert.Equal("123456789", customer.PassportNumber);
            Assert.Equal("Ivanov Ivan", customer.FullName);
            Assert.Equal(new DateTime(1980, 5, 15), customer.BirthDate);
        }

        [Fact]
        public void Customer_DefaultValues_AreSet()
        {
            // Arrange & Act
            var customer = new Customer();

            // Assert
            Assert.Equal(string.Empty, customer.PassportNumber);
            Assert.Equal(string.Empty, customer.FullName);
            Assert.Equal(default(DateTime), customer.BirthDate);
        }
    }

    // Тесты для модели Flight
    public class FlightModelTests
    {
        [Fact]
        public void Flight_Properties_WorkCorrectly()
        {
            // Arrange
            var departureTime = DateTime.Now.AddDays(1);
            var arrivalTime = departureTime.AddHours(4);

            // Act
            var flight = new Flight
            {
                Id = 1,
                FlightNumber = "SU100",
                DepartureCity = "Moscow",
                ArrivalCity = "London",
                AircraftType = AircraftType.Boeing737,
                DepartureTime = departureTime,
                ArrivalTime = arrivalTime
            };

            // Assert
            Assert.Equal(1, flight.Id);
            Assert.Equal("SU100", flight.FlightNumber);
            Assert.Equal("Moscow", flight.DepartureCity);
            Assert.Equal("London", flight.ArrivalCity);
            Assert.Equal(AircraftType.Boeing737, flight.AircraftType);
            Assert.Equal(departureTime, flight.DepartureTime);
            Assert.Equal(arrivalTime, flight.ArrivalTime);
        }

        [Fact]
        public void Flight_DefaultValues_AreSet()
        {
            // Arrange & Act
            var flight = new Flight();

            // Assert
            Assert.Equal(string.Empty, flight.FlightNumber);
            Assert.Equal(string.Empty, flight.DepartureCity);
            Assert.Equal(string.Empty, flight.ArrivalCity);
            Assert.Equal(default(AircraftType), flight.AircraftType);
            Assert.Equal(default(DateTime), flight.DepartureTime);
            Assert.Equal(default(DateTime), flight.ArrivalTime);
        }
    }

    // Тесты для InMemory репозиториев
    public class InMemoryRepositoriesTests
    {
        private readonly FlightRepository _flightRepository;
        private readonly BookingRepository _bookingRepository;
        private readonly List<Customer> _customers;

        public InMemoryRepositoriesTests()
        {
            _flightRepository = new FlightRepository();
            _bookingRepository = new BookingRepository();
            _customers = DataSeeder.SeedCustomers();
        }
    }

    // Тесты для BookingService
    public class BookingServiceTests
    {
        private readonly BookingService _bookingService;
        private readonly FlightRepository _flightRepository;
        private readonly BookingRepository _bookingRepository;

        public BookingServiceTests()
        {
            _flightRepository = new FlightRepository();
            _bookingRepository = new BookingRepository();
            _bookingService = new BookingService(_flightRepository, _bookingRepository);
        }

    }

    // Тесты для AircraftType enum
    public class AircraftTypeTests
    {
        [Fact]
        public void AircraftType_Values_AreCorrect()
        {
            // Arrange & Act
            var values = Enum.GetValues(typeof(AircraftType));

            // Assert
            Assert.Equal(4, values.Length);
            Assert.Contains(AircraftType.Boeing737, (IEnumerable<AircraftType>)values);
            Assert.Contains(AircraftType.AirbusA320, (IEnumerable<AircraftType>)values);
            Assert.Contains(AircraftType.Boeing787, (IEnumerable<AircraftType>)values);
            Assert.Contains(AircraftType.AirbusA380, (IEnumerable<AircraftType>)values);
        }
    }
}