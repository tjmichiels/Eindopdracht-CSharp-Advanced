using RestaurantReservationSystem.Composites;

namespace RestaurantReservationSystem.Models;

public class Table
{
    public int Id { get; set; }
    public int Seats { get; set; }
    public bool IsAvailable { get; set; } = true;

    public RestaurantRoom Room { get; set; }
}