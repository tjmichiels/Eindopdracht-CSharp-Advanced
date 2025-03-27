using RestaurantReservationSystem.Models;

namespace RestaurantReservationSystem.Composites;

public class RestaurantRoom : IRestaurantComponent
{
    public string Name { get; }

    // tafels in deze ruimte
    public List<Table> Tables { get; } = new List<Table>();

    public RestaurantRoom(string name)
    {
        Name = name;
    }

    public void AddTable(Table table) => Tables.Add(table);

    public void DisplayInfo()
    {
        Console.WriteLine($"Restaurant Room: {Name}");
        if (Tables.Count <= 0)
        {
            Console.WriteLine(" No tables in this room.");
            return;
        }

        // Tafels in deze ruimte
        Console.WriteLine(" Tafels:");
        foreach (var table in Tables)
        {
            Console.WriteLine($"  Tafel {table.Id} (Zitplaatsen: {table.Seats}, Beschikbaar: {table.IsAvailable})");
        }
    }
}