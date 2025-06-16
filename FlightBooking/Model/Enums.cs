namespace FlightBooking.Domain.Models
{
    /// <summary>
    /// Типы воздушных судов, используемые авиакомпанией
    /// </summary>
    public enum AircraftType
    {
        /// <summary>Боинг 737 (узкофюзеляжный)</summary>
        Boeing737,

        /// <summary>Аэробус A320 (узкофюзеляжный)</summary>
        AirbusA320,

        /// <summary>Боинг 787 Dreamliner (широкофюзеляжный)</summary>
        Boeing787,

        /// <summary>Аэробус A380 (двухпалубный)</summary>
        AirbusA380
    }
}