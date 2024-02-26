using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment1.Models
{
    [Table("CarRentals")] 
    public class CarRental
    {
        [Key]
        public int RentalId { get; set; }

        [Required(ErrorMessage = "Please select a pickup date")]
        [Display(Name = "Pickup Date")]
        [DataType(DataType.Date)]
        public DateTime PickupDate { get; set; }

        [Required(ErrorMessage = "Please select a return date")]
        [Display(Name = "Return Date")]
        [DataType(DataType.Date)]
        public DateTime ReturnDate { get; set; }

        public decimal PricePerDay { get; set; }

        public string Model { get; set; }

        public string Brand { get; set; }
        public int Year { get; set; }

        public bool IsAvailable { get; set; }

        [ForeignKey("Car")]
        public int CarId { get; set; }

        [Required(ErrorMessage = "Please select a car")]
        public Cars Car { get; set; }

    }
}
