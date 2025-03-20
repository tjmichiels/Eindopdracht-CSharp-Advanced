using RestaurantReservationSystem.Models;

namespace RestaurantReservationSystem.Observers;

public class EmailNotificationObserver : IObserver
{
    public async Task NotifyAsync(Reservation reservation)
    {
        // await EmailService.SendEmailAsync(reservation.CustomerName, \"Uw reservering is bevestigd.\");
    }
}