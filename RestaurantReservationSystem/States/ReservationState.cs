using RestaurantReservationSystem.Models;

namespace RestaurantReservationSystem.Enums;

public abstract class ReservationState
{
    public abstract void Handle(Reservation reservation);
    public abstract string Name { get; }
}