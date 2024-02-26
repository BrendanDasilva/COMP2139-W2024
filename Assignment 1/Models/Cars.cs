using System.ComponentModel.DataAnnotations;

namespace Assignment1.Models
{
    public class Cars
    {
    public Cars()
    {
      CarRentals = new HashSet<CarRental>();
    }
    [Key]
        public int CarId { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public double PricePerDay { get; set; }
        public bool IsAvailable { get; set; }

        public string DisplayName => $"{Brand} {Model}";

        public ICollection<CarRental> CarRentals { get; set; }
    }
}
