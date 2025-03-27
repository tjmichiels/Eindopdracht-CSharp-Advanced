using RestaurantReservationSystem.Enums;

namespace RestaurantReservationSystem.Models;

public class Reservation
{
    public Guid Id { get; set; }
    public string GuestName { get; set; }
    public DateTime DateTime { get; set; }
    public int NumberOfGuests { get; set; }
    public ReservationState ReservationState { get; set; } // State Pattern
    public virtual string Details { get; set; } // voor zowel Builder als Decorator Pattern
    public string ReservationType { get; set; } // voor Strategy Pattern

    public Table ReservedTable { get; set; }
}