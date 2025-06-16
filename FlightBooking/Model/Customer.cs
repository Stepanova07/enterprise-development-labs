namespace FlightBooking.Domain.Models
{
    /// <summary>
    /// Представляет данные пассажира (клиента авиакомпании)
    /// </summary>
    public class Customer
    {
        /// <summary>Уникальный идентификатор клиента</summary>
        public int Id { get; set; }

        /// <summary>Номер паспорта (серия и номер без пробелов)</summary>
        public string PassportNumber { get; set; } = string.Empty;

        /// <summary>Полное имя клиента (Фамилия Имя Отчество)</summary>
        public string FullName { get; set; } = string.Empty;

        /// <summary>Дата рождения клиента</summary>
        public DateTime BirthDate { get; set; }
    }
}