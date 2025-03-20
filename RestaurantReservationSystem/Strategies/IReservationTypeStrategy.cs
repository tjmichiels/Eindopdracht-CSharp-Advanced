using RestaurantReservationSystem.Models;

namespace RestaurantReservationSystem.Strategies;

public interface IReservationTypeStrategy
{
    void SetReservationType(Reservation reservation);
}