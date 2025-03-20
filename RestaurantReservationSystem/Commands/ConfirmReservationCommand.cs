using RestaurantReservationSystem.Enums;
using RestaurantReservationSystem.Models;

namespace RestaurantReservationSystem.Commands;

public class ConfirmReservationCommand : IReservationCommand
{
    private readonly Reservation _reservation;

    public ConfirmReservationCommand(Reservation reservation)
    {
        this._reservation = reservation;
    }

    public void Execute()
    {
        _reservation.ReservationState = ReservationState.Confirmed;
    }
}