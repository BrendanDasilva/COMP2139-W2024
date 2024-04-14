using Assignment1.Models;
using System.ComponentModel.DataAnnotations;

namespace Assignment1.Models
{
    public class HotelBooking
    {
        [Key]
        public int BookingId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }

        public int  HotelId { get; set; }
        public Hotel Hotel { get; set; }
    }
}
