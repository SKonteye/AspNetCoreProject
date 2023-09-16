namespace Chapter9_11_service_lifetimes
{
    public class Repository
    {
        private readonly DataContext _dataContext;
        public Repository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public int RowCount => _dataContext.RowCount;
    }
}
