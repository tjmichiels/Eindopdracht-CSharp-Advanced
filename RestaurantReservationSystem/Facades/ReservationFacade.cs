using RestaurantReservationSystem.Concurrency;
using RestaurantReservationSystem.Managers;
using RestaurantReservationSystem.Models;
using RestaurantReservationSystem.Observers;
using RestaurantReservationSystem.Services;
using RestaurantReservationSystem.Strategies;

namespace RestaurantReservationSystem.Facades;

public class ReservationFacade
{
    // private readonly NotificationService _notificationService = new NotificationService();

    public Task<bool> CreateReservationAsync(
        Reservation reservation,
        IReservationTypeStrategy reservationTypeStrategy)
    {
        return FuturesAndPromises.RunAsync(() =>
        {
            // Reserveringstype (Strategy Pattern)
            reservationTypeStrategy.SetReservationType(reservation);

            // Zoek een beschikbare tafel (Singleton Pattern)
            var table = TableManager.Instance.GetAvailableTable(reservation.NumberOfGuests);
            if (table == null) return false;

            // Reserveer tafel
            table.IsAvailable = false;
            reservation.ReservedTable = table;

            // Voeg reservering toe (Singleton Pattern)
            ReservationManager.Instance.AddReservation(reservation);

            return true;
        });
    }
}