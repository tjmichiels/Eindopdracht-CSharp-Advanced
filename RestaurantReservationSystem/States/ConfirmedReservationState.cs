using RestaurantReservationSystem.Enums;
using RestaurantReservationSystem.Models;

namespace RestaurantReservationSystem.States;

public class ConfirmedReservationState : ReservationState
{
    public override void Handle(Reservation reservation)
    {
        reservation.ReservationState = this;
    }
    
    public override string Name => "Confirmed";
}