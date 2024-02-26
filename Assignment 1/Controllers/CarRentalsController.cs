using Assignment1.Data;
using Assignment1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;


namespace Assignment1.Controllers
{
    public class CarRentalsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CarRentalsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(int carId)
        {
            var carRentals = _context.CarRentals
                .Where(carRental => carRental.CarId == carId)
                .ToList();

            ViewBag.CarRentals = carRentals;
            return View(carRentals);
        }

        [HttpGet]
        public IActionResult Create(int carId)
        {
            var car = _context.Cars.Find(carId);
            if (car == null)
            {
                return NotFound();
            }

            var carRental = new CarRental
            {
                CarId = carId,
                PickupDate = DateTime.Today,
                ReturnDate = DateTime.Today.AddDays(1)
            };

            ViewBag.CarBrand = car.Brand;
            ViewBag.CarModel = car.Model;
            ViewBag.CarPricePerDay = car.PricePerDay;

            return View(carRental);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("RentalId,CarId,PickupDate,ReturnDate")] CarRental carRental)
        {
            if (ModelState.IsValid)
            {
                _context.CarRentals.Add(carRental);
                _context.SaveChanges();

                MarkCarAsUnavailable(carRental.CarId);

                return RedirectToAction("Index", new { RentalID = carRental.RentalId });
            }

            ViewData["CarId"] = new SelectList(_context.Cars.Where(car => car.IsAvailable), "CarId", "DisplayName", carRental.CarId);
            return View(carRental);
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carRental = _context.CarRentals
                .Include(c => c.Car)
                .FirstOrDefault(m => m.RentalId == id);

            if (carRental == null)
            {
                return NotFound();
            }

            return View(carRental);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carRental = _context.CarRentals.Find(id);

            if (carRental == null)
            {
                return NotFound();
            }

            ViewData["CarId"] = new SelectList(_context.Cars.Where(car => car.IsAvailable), "CarId", "DisplayName", carRental.CarId);
            return View(carRental);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("RentalId,CarId,PickupDate,ReturnDate")] CarRental carRental)
        {
            if (id != carRental.RentalId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carRental);
                    _context.SaveChanges();

                    MarkCarAsUnavailable(carRental.CarId);

                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarRentalExists(carRental.RentalId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            ViewData["CarId"] = new SelectList(_context.Cars.Where(car => car.IsAvailable), "CarId", "DisplayName", carRental.CarId);
            return View(carRental);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carRental = _context.CarRentals
                .Include(c => c.Car)
                .FirstOrDefault(m => m.RentalId == id);

            if (carRental == null)
            {
                return NotFound();
            }

            return View(carRental);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var carRental = _context.CarRentals.Find(id);
            _context.CarRentals.Remove(carRental);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool CarRentalExists(int rentalId)
        {
            return _context.CarRentals.Any(e => e.RentalId == rentalId);
        }

        private void MarkCarAsUnavailable(int carId)
        {
            var car = _context.Cars.FirstOrDefault(c => c.CarId == carId);
            if (car != null)
            {
                car.IsAvailable = false;
                _context.SaveChanges();
            }
        }
    }
}
