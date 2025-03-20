using RestaurantReservationSystem.Builders;
using RestaurantReservationSystem.Models;

namespace RestaurantReservationSystem;

class Program
{
    static void Main(string[] args)
    {
        Reservation reservation1 = new ReservationBuilder()
            .SetGuestName("Visch")
            .SetDateTime(new DateTime(2025, 03, 20))
            .SetNumberOfGuests(3)
            .Build();
        
        Reservation reservation2 = new ReservationBuilder()
            .SetGuestName("Janssen")
            .SetDateTime(new DateTime(2025, 03, 20))
            .SetNumberOfGuests(5)
            .SetDetails("Komen misschien iets later")
            .Build();
            
    }
}