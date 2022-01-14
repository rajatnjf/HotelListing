using System.ComponentModel.DataAnnotations;

namespace HotelListing.Models
{
    public class CreateCountryDTO
    {
        [Required]
        [StringLength(50, ErrorMessage = "Country Name too long.")]
        public string Name { get; set; }
    }
}
