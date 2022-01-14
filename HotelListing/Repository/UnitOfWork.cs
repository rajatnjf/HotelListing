using HotelListing.Data;
using HotelListing.IRepository;

namespace HotelListing.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly HotelContext _dbContext;
        private IGenericRepository<Country> _countryRepository;
        private IGenericRepository<Hotel> _hotelRepository;

        public UnitOfWork(HotelContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IGenericRepository<Country> countryRepository =>
            _countryRepository ??= new GenericRepository<Country>(_dbContext);

        public IGenericRepository<Hotel> hotelRepository =>
        _hotelRepository ??= new GenericRepository<Hotel>(_dbContext);

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
        public void Dispose()
        {
            _dbContext.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
