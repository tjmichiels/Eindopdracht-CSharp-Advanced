using RestaurantReservationSystem.Models;

namespace RestaurantReservationSystem.Strategies;

public class OnlineReservationStrategy : IReservationTypeStrategy
{
    public void SetReservationType(Reservation reservation)
    {
        reservation.ReservationType = "Online";
    }
}