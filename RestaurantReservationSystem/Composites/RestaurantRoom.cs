namespace RestaurantReservationSystem.Composites;

public class RestaurantRoom : IRestaurantComponent
{
    public string Name { get; }

    public RestaurantRoom(string name)
    {
        Name = name;
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Restaurant Room: {Name}");
    }
}