using RestaurantReservationSystem.Models;
using RestaurantReservationSystem.Observers;

namespace RestaurantReservationSystem.Services;

public class NotificationService
{
    private List<IObserver> _observers = new List<IObserver>();
    
    public void Subscribe(IObserver observer) => _observers.Add(observer);
    public void Unsubscribe(IObserver observer) => _observers.Remove(observer);

    public async Task NotifyAllAsync(Reservation reservation)
    {
        foreach (IObserver observer in _observers)
        {
            await observer.NotifyAsync(reservation);
        }
    }
}