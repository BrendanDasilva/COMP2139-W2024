using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Assignment1.Models
{
    public class Hotel
    {
        [Key]
        public int HotelId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public double PricePerNight { get; set; }
        public string Amenities { get; set; }
        public bool IsAvailable { get; set; }
        public string ServiceType { get; set; }

       // public ICollection<HotelBooking> HotelBookings { get; set; }
        public int BookingId { get; internal set; }
    }
}
