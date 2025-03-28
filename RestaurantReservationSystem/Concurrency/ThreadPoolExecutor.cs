namespace RestaurantReservationSystem.Concurrency;

public static class ThreadPoolExecutor
{
    public static void QueueTask(Action action)
    {
        ThreadPool.QueueUserWorkItem(_ => action());
    }
}