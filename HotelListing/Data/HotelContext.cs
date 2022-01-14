using Microsoft.EntityFrameworkCore;

namespace HotelListing.Data
{
    public class HotelContext : DbContext
    {
        public HotelContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Hotel> Hotels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>()
                .HasData(new Country { Id = 1, Name = "India" },
                    new Country { Id = 2, Name = "US" });
            modelBuilder.Entity<Hotel>()
                .HasData(new Hotel()
                {
                    Id = 1,
                    Name = "First Hotel in India",
                    CountryId = 1,
                    City = "Delhi",
                    Rating = 4.5

                }, new Hotel()
                {
                    Id = 2,
                    Name = "Second Hotel in India",
                    CountryId = 1,
                    City = "Mumbai",
                    Rating = 4.3

                }, new Hotel()
                {
                    Id = 3,
                    Name = "First Hotel in US",
                    CountryId = 2,
                    City = "New York",
                    Rating = 4.2

                });
            base.OnModelCreating(modelBuilder);
        }



    }
}
