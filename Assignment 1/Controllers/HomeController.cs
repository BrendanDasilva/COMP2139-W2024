using Assignment1.Data;
using Assignment1.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment1.Controllers
{
  public class HomeController : Controller
  {
    private readonly ApplicationDbContext _context;

    public HomeController(ApplicationDbContext context)
    {
      _context = context;
    }

    public async Task<IActionResult> Index()
    {
      var randomFlight = await _context.Flights.OrderBy(r => Guid.NewGuid()).FirstOrDefaultAsync();
      var randomHotel = await _context.Hotels.OrderBy(r => Guid.NewGuid()).FirstOrDefaultAsync();
      var randomCar = await _context.Cars.OrderBy(r => Guid.NewGuid()).FirstOrDefaultAsync();

      var viewModel = new RandomTripViewModel
      {
        RandomFlight = randomFlight,
        RandomHotel = randomHotel,
        RandomCar = randomCar
      };

      return View(viewModel);
    }


    public IActionResult About()
    {
      return View();
    }

    public async Task<IActionResult> Search(string destination, DateTime? departureDate, DateTime? returnDate)
    {
      IQueryable<Flight> results = _context.Flights;

      if (!string.IsNullOrEmpty(destination))
      {
        results = results.Where(f => f.Destination.Contains(destination));
      }

      if (departureDate.HasValue)
      {
        results = results.Where(f => f.DepartureTime.Date >= departureDate.Value.Date);
      }

      if (returnDate.HasValue)
      {
        results = results.Where(f => f.ArrivalTime.Date <= returnDate.Value.Date);
      }

      if (Request.Headers["X-Requested-With"].ToString().Contains("XMLHttpRequest"))
      {
        return PartialView("_SearchResults", await results.ToListAsync());
      }

      return View("SearchResults", await results.ToListAsync());
    }

    public async Task<IActionResult> SearchCars(string location, string brand, string model)
    {
      IQueryable<Cars> query = _context.Cars.Where(c => c.IsAvailable);

      if (!string.IsNullOrEmpty(location))
      {
        query = query.Where(c => c.Location.Contains(location));
      }

      if (!string.IsNullOrEmpty(brand))
      {
        query = query.Where(c => c.Brand.Contains(brand));
      }

      if (!string.IsNullOrEmpty(model))
      {
        query = query.Where(c => c.Model.Contains(model));
      }

      var results = await query.ToListAsync();
      if (Request.Headers["X-Requested-With"].ToString().Contains("XMLHttpRequest"))
      {
        return PartialView("_CarSearchResults", results);
      }

      return View("CarSearchResults", results);
    }

    public async Task<IActionResult> SearchHotels(string location)
    {
      IQueryable<Hotel> query = _context.Hotels.Where(h => h.IsAvailable);

      if (!string.IsNullOrEmpty(location))
      {
        var locationTerms = location.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
        query = query.Where(h => locationTerms.Any(term => h.Location.Contains(term)));
      }

      var results = await query.ToListAsync();
      if (Request.Headers["X-Requested-With"].ToString().Contains("XMLHttpRequest"))
      {
        return PartialView("_HotelSearchResults", results);
      }

      return View("HotelSearchResults", results);
    }


  }
}
