namespace Chapter9_11_service_lifetimes
{
    public class DataContext
    {
        public int RowCount { get; } = Random.Shared.Next(1, 1000000);
    }
}