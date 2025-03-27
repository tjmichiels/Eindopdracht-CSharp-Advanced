using RestaurantReservationSystem.Models;

namespace RestaurantReservationSystem.Observers;

public class EmailNotificationObserver : IObserver
{
    public async Task NotifyAsync(Reservation reservation)
    {
        string roomName = reservation.ReservedTable.Room.Name;
        int tableId = reservation.ReservedTable.Id;

        string message = $"Beste {reservation.GuestName}, uw reservering is bevestigd:\n\n{reservation}\n";

        // await EmailService.SendEmailAsync(reservation.CustomerName, message);
        await Console.Out.WriteLineAsync(message);
    }
}