namespace RestaurantReservationSystem.Composites;

public class RestaurantBranch : IRestaurantComponent
{
    // Naam van de branche
    public string Name { get; }

    // Collectie van componenten binnen de branch
    private List<IRestaurantComponent> components = new List<IRestaurantComponent>();


    public RestaurantBranch(string name)
    {
        Name = name;
    }

    public void AddComponent(IRestaurantComponent component) => components.Add(component);

    public void DisplayInfo()
    {
        Console.WriteLine($"BRANCH: {Name}");

        if (components.Count == 0)
        {
            Console.WriteLine(" No components");
            return;
        }

        Console.WriteLine(" Components:");
        foreach (var restaurantComponent in components)
        {
            Console.Write("  ");
            restaurantComponent.DisplayInfo();
        }

        Console.WriteLine();
    }
}