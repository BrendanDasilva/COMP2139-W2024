using Assignment1.Data;
using Assignment1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment1.Controllers
{
    public class HotelBookingsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HotelBookingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: HotelBookings
        public async Task<IActionResult> Index(string sortOrder)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["LocationSortParm"] = sortOrder == "Location" ? "location_desc" : "Location";
            ViewData["PriceSortParm"] = sortOrder == "Price" ? "price_desc" : "Price";
            ViewData["AmenitiesSortParm"] = sortOrder == "Amenities" ? "amenities_desc" : "Amenities";
            ViewData["AvailableSortParm"] = sortOrder == "Available" ? "available_desc" : "Available";

            var hotels = from h in _context.Hotels
                         select h;

            switch (sortOrder)
            {
                case "name_desc":
                    hotels = hotels.OrderByDescending(h => h.Name);
                    break;
                case "Location":
                    hotels = hotels.OrderBy(h => h.Location);
                    break;
                case "location_desc":
                    hotels = hotels.OrderByDescending(h => h.Location);
                    break;
                case "Price":
                    hotels = hotels.OrderBy(h => h.PricePerNight);
                    break;
                case "price_desc":
                    hotels = hotels.OrderByDescending(h => h.PricePerNight);
                    break;
                case "Amenities":
                    hotels = hotels.OrderBy(h => h.Amenities);
                    break;
                case "amenities_desc":
                    hotels = hotels.OrderByDescending(h => h.Amenities);
                    break;
                case "Available":
                    hotels = hotels.OrderBy(h => h.IsAvailable);
                    break;
                case "available_desc":
                    hotels = hotels.OrderByDescending(h => h.IsAvailable);
                    break;
                default:
                    hotels = hotels.OrderBy(h => h.Name);
                    break;
            }

            return View(await hotels.AsNoTracking().ToListAsync());
        }

        // GET: HotelBookings/Book/5
        [HttpGet]
        public IActionResult Book(int hotelId)
        {
            var hotel = _context.Hotels.Find(hotelId);
            if (hotel == null)
            {
                return NotFound();
            }

            return View(hotel);
        }

        // POST: HotelBookings/CreateBooking
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Book(int hotelId, string customerName, string customerEmail, DateTime checkInDate, DateTime checkOutDate)
        {
            var hotel = _context.Hotels.Find(hotelId);
            if (hotel == null)
            {
                return NotFound();
            }

            if (checkInDate >= checkOutDate)
            {
                ModelState.AddModelError("checkInDate", "Check-in date must be before check-out date.");
            }

            if (!ModelState.IsValid)
            {
                return View("Confirmation", hotel);
            }

            try
            {
                var hotelBooking = new HotelBooking
                {
                    CustomerName = customerName,
                    CustomerEmail = customerEmail,
                    CheckInDate = checkInDate,
                    CheckOutDate = checkOutDate,
                    HotelId = hotelId
                };

                _context.HotelBookings.Add(hotelBooking);
                hotel.IsAvailable = false;
                _context.SaveChanges();

                return RedirectToAction("Confirmation", new { id = hotelBooking.BookingId });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "An error occurred while saving the booking to the database. Please try again.");
            }

            return View("Confirmation", hotel);
        }

        // GET: HotelBookings/Confirmation/5
        [HttpGet]
        public IActionResult Confirmation(int id)
        {
            var hotelBooking = _context.HotelBookings
                .Include(hb => hb.Hotel)
                .FirstOrDefault(hb => hb.BookingId == id);

            if (hotelBooking == null)
            {
                return NotFound();
            }

            return View(hotelBooking);
        }

        // GET: HotelBookings/CurrentBookings
        public IActionResult CurrentBookings()
        {
            var currentBookings = _context.HotelBookings
                .Include(hb => hb.Hotel)
                .ToList();

            return View("CurrentReservations");
        }

    }
}