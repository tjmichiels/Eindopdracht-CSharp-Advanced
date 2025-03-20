using System.Collections.Concurrent;
using RestaurantReservationSystem.Models;

namespace RestaurantReservationSystem.Managers;

public class TableManager
{
    private static readonly Lazy<TableManager> instance =
        new Lazy<TableManager>(() => new TableManager());

    // Concurrent Collections
    private readonly ConcurrentDictionary<int, Table> _tables = new ConcurrentDictionary<int, Table>();

    public static TableManager Instance => instance.Value;

    private TableManager()
    {
        // Initalisatie van de t afels
        _tables.TryAdd(1, new Table { Id = 1, Seats = 6 });
        _tables.TryAdd(2, new Table { Id = 2, Seats = 4 });
        _tables.TryAdd(3, new Table { Id = 3, Seats = 4 });
        _tables.TryAdd(4, new Table { Id = 4, Seats = 4 });
        _tables.TryAdd(5, new Table { Id = 5, Seats = 5 });
        _tables.TryAdd(6, new Table { Id = 6, Seats = 5 });
        _tables.TryAdd(7, new Table { Id = 7, Seats = 5 });
        _tables.TryAdd(8, new Table { Id = 8, Seats = 6 });
        _tables.TryAdd(9, new Table { Id = 9, Seats = 6 });
    }

    public Table GetAvailableTable(int guests)
    {
        return _tables.Values.FirstOrDefault(t => t.IsAvailable && t.Seats >= guests) ?? throw new InvalidOperationException();
    }

}