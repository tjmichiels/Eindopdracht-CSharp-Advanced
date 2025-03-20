using RestaurantReservationSystem.Models;

namespace RestaurantReservationSystem.Observers;

public interface IObserver
{
    Task NotifyAsync(Reservation reservation);
}