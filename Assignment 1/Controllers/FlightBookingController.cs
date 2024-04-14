using Assignment1.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Assignment1.Data;

namespace Assignment1.Controllers
{
    public class FlightBookingController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FlightBookingController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(string sortOrder)
        {
            ViewData["CurrentSort"] = sortOrder;
            IQueryable<Flight> flights = _context.Flights;

            switch (sortOrder)
            {
                case "AirlineAsc":
                    flights = flights.OrderBy(f => f.Airline);
                    break;
                case "AirlineDesc":
                    flights = flights.OrderByDescending(f => f.Airline);
                    break;
                case "DestinationAsc":
                    flights = flights.OrderBy(f => f.Destination);
                    break;
                case "DestinationDesc":
                    flights = flights.OrderByDescending(f => f.Destination);
                    break;
                case "DepartureTimeAsc":
                    flights = flights.OrderBy(f => f.DepartureTime);
                    break;
                case "DepartureTimeDesc":
                    flights = flights.OrderByDescending(f => f.DepartureTime);
                    break;
                case "PriceAsc":
                    flights = flights.OrderBy(f => f.Price);
                    break;
                case "PriceDesc":
                    flights = flights.OrderByDescending(f => f.Price);
                    break;
                default:
                    flights = flights.OrderBy(f => f.Airline); // Default sorting
                    break;
            }

            return View(flights.ToList());
        }

        [HttpGet]
        public async Task<IActionResult> Book(int flightId)
        {
            var flight = await _context.Flights.FindAsync(flightId);
            if (flight == null)
            {
                return NotFound();
            }

            var viewModel = new FlightBookingViewModel
            {
                Airline = flight.Airline,
                DepartureAirport = flight.DepartureAirport,
                ArrivalAirport = flight.ArrivalAirport,
                DepartureTime = flight.DepartureTime,
                ArrivalTime = flight.ArrivalTime,
                Price = flight.Price,
                BookingDate = DateTime.Now
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Book([Bind("FlightId,CustomerName,CustomerEmail,BookingDate")] FlightBooking booking)
        {
            if (ModelState.IsValid)
            {
                // Add the booking to the database
                _context.Add(booking);
                await _context.SaveChangesAsync();

                // Redirect to the Confirmation action, passing the ID of the new booking
                return RedirectToAction("Confirmation", new { id = booking.FlightBookingId });
            }

            // Prepare the viewModel for the form view if the model state is not valid
            var flight = await _context.Flights.FindAsync(booking.FlightId);
            if (flight == null)
            {
                return NotFound();
            }

            var viewModel = new FlightBookingViewModel
            {
                Airline = flight.Airline,
                DepartureAirport = flight.DepartureAirport,
                ArrivalAirport = flight.ArrivalAirport,
                DepartureTime = flight.DepartureTime,
                ArrivalTime = flight.ArrivalTime,
                Price = flight.Price,
                // Populate CustomerName, CustomerEmail, and BookingDate from the submitted booking if needed
                CustomerName = booking.CustomerName,
                CustomerEmail = booking.CustomerEmail,
                BookingDate = booking.BookingDate
            };

            // Return to the "Book" view with the viewModel
            return View("Book", viewModel);
        }


        public IActionResult Confirmation(int id)
        {
            var booking = _context.FlightBookings
                .Include(fb => fb.Flight)
                .FirstOrDefault(b => b.FlightBookingId == id);

            if (booking == null)
            {
                return NotFound();
            }

            // Return the confirmation view, passing in the booking as the model
            return View(booking);
        }
    }
}