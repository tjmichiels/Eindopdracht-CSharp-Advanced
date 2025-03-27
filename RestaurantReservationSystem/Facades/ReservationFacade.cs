using RestaurantReservationSystem.Managers;
using RestaurantReservationSystem.Models;
using RestaurantReservationSystem.Observers;
using RestaurantReservationSystem.Services;
using RestaurantReservationSystem.Strategies;

namespace RestaurantReservationSystem.Facades;

public class ReservationFacade
{
    private readonly NotificationService _notificationService = new NotificationService();

    public async Task<bool> CreateReservationAsync(
        Reservation reservation,
        IReservationTypeStrategy reservationTypeStrategy)
    {
        // Reserveringstype (Strategy Pattern)
        reservationTypeStrategy.SetReservationType(reservation);

        // Zoek een beschikbare tafel (Singleton Pattern)
        var table = TableManager.Instance.GetAvailableTable(reservation.NumberOfGuests);
        if (table == null) return false;

        // Reserveer tafel
        table.IsAvailable = false;

        // Voeg reservering toe (Singleton Pattern)
        ReservationManager.Instance.AddReservation(reservation);

        // Notificeer klant (Observer Pattern)
        _notificationService.Subscribe(new EmailNotificationObserver());
        await _notificationService.NotifyAllAsync(reservation);

        return true;
    }
}