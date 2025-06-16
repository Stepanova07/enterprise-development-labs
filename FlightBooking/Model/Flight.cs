using System;

namespace FlightBooking.Domain.Models
{
    /// <summary>
    /// Представляет информацию об авиарейсе
    /// </summary>
    public class Flight
    {
        /// <summary>Уникальный идентификатор рейса</summary>
        public int Id { get; set; }

        /// <summary>Номер рейса (например, "SU 123")</summary>
        public string FlightNumber { get; set; } = string.Empty;

        /// <summary>Город вылета (код IATA или полное название)</summary>
        public string DepartureCity { get; set; } = string.Empty;

        /// <summary>Город прибытия (код IATA или полное название)</summary>
        public string ArrivalCity { get; set; } = string.Empty;
        
        /// <summary>Тип воздушного судна</summary>
        public AircraftType AircraftType { get; set; }

        /// <summary>Дата и время вылета по расписанию</summary>
        public DateTime DepartureTime { get; set; }

        /// <summary>Дата и время прибытия по расписанию</summary>
        public DateTime ArrivalTime { get; set; }
    }
}