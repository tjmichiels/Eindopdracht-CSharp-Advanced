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
        var hoofdzaal = new RestaurantRoom("Hoofdzaal");
        var terras = new RestaurantRoom("Terras");

        var mainBranch = new RestaurantBranch("Almere Centrum");
        mainBranch.AddComponent(hoofdzaal);
        mainBranch.AddComponent(terras);

        var tableManager = TableManager.Instance; // Singleton Pattern


        tableManager.AddTable(new Table { Id = 1, Seats = 6, Room = hoofdzaal });
        tableManager.AddTable(new Table { Id = 2, Seats = 4, Room = terras });

        // Voeg tafels toe aan ruimtes
        hoofdzaal.AddTable(tableManager.GetTableById(1));
        terras.AddTable(tableManager.GetTableById(2));

        mainBranch.DisplayInfo();

        Thread.Sleep(1000);
        
        // Builder Pattern
        // reservering aanmaken
        var builder = new ReservationBuilder();
        var reservation = builder
            .SetGuestName("Anna de Vries")
            .SetDateTime(new DateTime(2025, 11, 28, 23, 59, 0))
            .SetNumberOfGuests(4)
            .SetDetails("Komen misschien een kwartier later")
            .Build();

        // Decorator Pattern
        // eventuele speciale verzoeken toevoegen
        reservation = new SpecialRequestDecorator(reservation, "1 persoon gluten- en lactosevrij");

        
        // Strategy Pattern
        // reserveringstype instellen
        var onlineReservation = new OnlineReservationStrategy();
        
        Thread.Sleep(1000);

        // Facade Pattern
        // reservering aanmaken via facade
        var reservationFacade = new ReservationFacade(); // deze roept de Singletons aan (Singleton Pattern)
        bool success = await reservationFacade.CreateReservationAsync(reservation, onlineReservation);

        if (!success)
        {
            Console.WriteLine("Reservering mislukt: Geen beschikbare tafel.");
            return;
        }

        // Bij succes wordt een notificatie verzonden in ReservationFacade.cs (Observer Pattern)
        
        Thread.Sleep(1000);

        Console.WriteLine("Reservering succesvol aangemaakt.\n");
        
        Thread.Sleep(1000);

        // Command Pattern
        // reservering bevestigen
        var confirmCommand = new ConfirmReservationCommand(reservation);
        confirmCommand.Execute();

        Thread.Sleep(1000);
        
        // State Pattern
        Console.WriteLine($"Status van de reservering: {reservation.ReservationState.Name}\n");
        
        Thread.Sleep(1000);
        
        // Tafel 1 staat nu niet meer beschikbaar
        mainBranch.DisplayInfo();
    }
}