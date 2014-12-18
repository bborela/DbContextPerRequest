namespace DataContext.Implementations
{
    public class MyEntitiesDataContext : DataContext<MyEntities>, IMyEntitiesDataContext
    {
        private MyEntities _context;

        public override MyEntities Context
        {
            get { return (_context ?? (_context = new MyEntities())); }
        }

        public override void Dispose(bool disposing)
        {
            if (!disposing) return;
            if (_context == null) return;
            _context.Dispose();
            _context = null;
        }
    }
}
