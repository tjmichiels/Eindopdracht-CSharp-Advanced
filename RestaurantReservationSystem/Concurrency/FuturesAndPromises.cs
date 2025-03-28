namespace RestaurantReservationSystem.Concurrency;

public static class FuturesAndPromises
{
    public static Task<T> RunAsync<T>(Func<T> function)
    {
        return Task.Run(function);
    }
}