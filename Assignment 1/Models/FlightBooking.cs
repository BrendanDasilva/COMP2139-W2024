using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment1.Models
{
    public class FlightBooking
    {
        [Key]
        public int FlightBookingId { get; set; }

        public int FlightId { get; set; }
        public virtual Flight Flight { get; set; }

        public string Airline { get; set; }
        public string DepartureAirport { get; set; }
        public string ArrivalAirport { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public DateTime BookingDate { get; set; }
    }
}
