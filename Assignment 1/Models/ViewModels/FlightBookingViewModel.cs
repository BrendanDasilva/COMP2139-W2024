using System;
using System.ComponentModel.DataAnnotations;

namespace Assignment1.Models
{
    public class FlightBookingViewModel
    {
        public int FlightId { get; set; }
        public string Airline { get; set; }
        public string DepartureAirport { get; set; }
        public string ArrivalAirport { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Please enter your name")]
        public string CustomerName { get; set; }

        [Required(ErrorMessage = "Please enter your email")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address")]
        public string CustomerEmail { get; set; }

        [Required(ErrorMessage = "Please select a booking date")]
        public DateTime BookingDate { get; set; }
    }
}
