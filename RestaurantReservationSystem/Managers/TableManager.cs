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
    }

    public void AddTable(Table table)
    {
        _tables.TryAdd(table.Id, table);
    }

    public Table GetAvailableTable(int guests)
    {
        return _tables.Values.FirstOrDefault(t => t.IsAvailable && t.Seats >= guests);
    }

    public Table GetTableById(int id)
    {
        return _tables.TryGetValue(id, out var table) ? table : null;
    }
}