using RestaurantReservationSystem.Models;

namespace RestaurantReservationSystem.Strategies;

public class ManualReservationStrategy : IReservationTypeStrategy
{
    public void SetReservationType(Reservation reservation)
    {
        reservation.ReservationType = "Manual";
    }
}