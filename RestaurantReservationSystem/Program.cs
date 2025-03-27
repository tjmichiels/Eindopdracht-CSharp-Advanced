using RestaurantReservationSystem.Builders;
using RestaurantReservationSystem.Commands;
using RestaurantReservationSystem.Composites;
using RestaurantReservationSystem.Decorators;
using RestaurantReservationSystem.Facades;
using RestaurantReservationSystem.Managers;
using RestaurantReservationSystem.Models;
using RestaurantReservationSystem.Observers;
using RestaurantReservationSystem.Services;
using RestaurantReservationSystem.Strategies;

namespace RestaurantReservationSystem;

class Program
{
    static async Task Main(string[] args)
    {
        // Composite Pattern
        // restaurantstructuur opzetten
        var mainBranch = new RestaurantBranch("Almere Centrum");
        mainBranch.AddComponent(new RestaurantRoom("Hoofdzaal"));
        mainBranch.AddComponent(new RestaurantRoom("Terras"));
        
        mainBranch.DisplayInfo();

        // Builder Pattern
        // reservering aanmaken
        var builder = new ReservationBuilder();
        var reservation = builder
            .SetGuestName("Anna de Vries")
            .SetDateTime(DateTime.Now.AddDays(2))
            .SetNumberOfGuests(4)
            .Build();

        // Decorator Pattern
        // eventuele speciale verzoeken toevoegen
        reservation = new SpecialRequestDecorator(reservation, "1 persoon gluten- en lactosevrij");
        

        // Strategy Pattern
        // reserveringstype instellen
        var reservationTypeStrategy = new OnlineReservationStrategy();

        // Facade Pattern
        // reservering aanmaken via facade
        var reservationFacade = new ReservationFacade(); // deze roept de Singletons aan (Singleton Pattern)
        bool success = await reservationFacade.CreateReservationAsync(reservation, reservationTypeStrategy);

        if (!success)
        {
            Console.WriteLine("Reservering mislukt: Geen beschikbare tafel.");
            return;
           
        }
        Console.WriteLine("Reservering succesvol aangemaakt.");

        // Command Pattern
        // reservering bevestigen
        var confirmCommand = new ConfirmReservationCommand(reservation);
        confirmCommand.Execute();

        // State Pattern
        Console.WriteLine($"Status van de reservering: {reservation.ReservationState.Name}");

        // Observer Pattern
        // notificaties verzenden
        var notificationService = new NotificationService();
        notificationService.Subscribe(new EmailNotificationObserver());
        await notificationService.NotifyAllAsync(reservation);
        Console.WriteLine("Notificatie verzonden.");
    }
}