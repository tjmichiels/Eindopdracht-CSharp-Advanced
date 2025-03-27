using RestaurantReservationSystem.Enums;
using RestaurantReservationSystem.Models;
using RestaurantReservationSystem.Observers;
using RestaurantReservationSystem.Services;
using RestaurantReservationSystem.States;

namespace RestaurantReservationSystem.Commands;

public class ConfirmReservationCommand : IReservationCommand
{
    private readonly Reservation _reservation;
    private readonly NotificationService _notificationService;

    public ConfirmReservationCommand(Reservation reservation)
    {
        _reservation = reservation;
        _notificationService = new NotificationService();
        _notificationService.Subscribe(new EmailNotificationObserver());
    }

    public async void Execute()
    {
        _reservation.ReservationState = new ConfirmedReservationState();
        
        // notificeer de klant
        await _notificationService.NotifyAllAsync(_reservation);
    }
}