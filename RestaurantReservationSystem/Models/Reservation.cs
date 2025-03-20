using RestaurantReservationSystem.Enums;

namespace RestaurantReservationSystem.Models;

public class Reservation
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTime DateTime { get; set; }
    public int NumberOfGuests { get; set; }
    public ReservationState ReservationState { get; set; }
    public virtual string Details { get; set; } // voor zowel Builder als Decorator Pattern
    public string ReservationType { get; set; } // voor Strategy Pattern
}