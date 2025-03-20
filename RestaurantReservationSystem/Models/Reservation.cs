using RestaurantReservationSystem.Enums;

namespace RestaurantReservationSystem.Models;

public class Reservation
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTime DateTime { get; set; }
    public int NumberOfGuests { get; set; }
    public ReservationState ReservationState { get; set; } = ReservationState.Unconfirmed;
    public string Details { get; set; }
}