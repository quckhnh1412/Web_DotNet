using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HouseBuying.Models
{
    public class House
    {
        [Key]
        public int Id {  get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value greater than 0")]
        public int Bedrooms { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value greater than 0")]
        public int Bathrooms { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value greater than 0")]
        public int Squarefoot { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value greater than 0")]
        public decimal Price { get; set; }

        [Required]
        public string ImageURL { get; set; }

        [Required]
        public string Status { get; set; }

        // Foreign key relationship to the Address model
        public int AddressId { get; set; }
        [ForeignKey("AddressId")]
        public Address Address { get; set; }

        // You can add additional properties like images, features, etc. if needed
    }
}
