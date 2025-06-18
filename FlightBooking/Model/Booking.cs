namespace FlightBooking.Domain.Models
{
    /// <summary>
    /// Представляет бронирование авиабилета, связывающее клиента с конкретным рейсом
    /// </summary>
    public class Booking
    {
        /// <summary>Уникальный идентификатор бронирования</summary>
        public int Id { get; set; }

        /// <summary>Номер билета (может содержать буквы и цифры)</summary>
        public string TicketNumber { get; set; } = string.Empty; //

        /// <summary>Рейс, на который оформлено бронирование</summary>
        public Flight? Flight { get; set; }

        /// <summary>Клиент, оформивший бронирование</summary>
        public Customer? Customer { get; set; } 
    }
}
