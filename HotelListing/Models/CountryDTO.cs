using System.ComponentModel.DataAnnotations;

namespace HotelListing.Models
{
    public class CountryDTO : CreateCountryDTO
    {
        public int CountryId { get; set; }
        
        public IList<HotelDTO> Hotels { get; set; }
    }
}
