using HotelListing.Data;

namespace HotelListing.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Country> countryRepository { get; }
        IGenericRepository<Hotel> hotelRepository { get; }

        Task SaveAsync();
    }
}
