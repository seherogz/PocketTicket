using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PocketTicket.Data.Services;
using PocketTicket.Models;

namespace PocketTicket.Controllers
{
    public class ReservationsController : Controller
    {
        private readonly IReservationsService _reservationsService;

        public ReservationsController(IReservationsService reservationsService)
        {
            _reservationsService = reservationsService;
        }

        [HttpPost]
        public async Task<IActionResult> Index(int flightId)
        {
            var flight = await _reservationsService.GetByIdAsync(flightId); // Uçuşu alıyoruz.

            if (flight == null)
            {
                ViewBag.Message = "Uçuş bulunamadı.";
                return RedirectToAction("Index", "Flights");
            }

          
            var reservation = new Reservation
            {
                FlightId = flightId,
                ReservationDate = DateTime.Now,
            };

            _reservationsService.AddAsync(reservation);

            return RedirectToAction(nameof(Index)); // Rezervasyon işlemi tamamlandığında Index sayfasına dönüyoruz.
        }

        public async Task<IActionResult> Details(int id)
        {
            var reservation = await _reservationsService.GetByIdAsync(id);

            if (reservation == null)
            {
                return NotFound();
            }

            return View(reservation);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PassengerId, FlightId, ReservationDate, Status")] Reservation reservation)
        {
            if (ModelState.IsValid)
            {
                await _reservationsService.AddAsync(reservation);
                return RedirectToAction(nameof(Index));
            }
            return View(reservation);
        }


        public async Task<IActionResult> Edit(int id)
        {
            var reservation = await _reservationsService.GetByIdAsync(id);

            if (reservation == null)
            {
                return NotFound();
            }

            return View(reservation);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id, PassengerId, FlightId, ReservationDate, Status")] Reservation reservation)
        {
            if (id != reservation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _reservationsService.UpdateAsync(reservation);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await ReservationExists(reservation.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(reservation);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var reservation = await _reservationsService.GetByIdAsync(id);

            if (reservation == null)
            {
                return NotFound();
            }

            return View(reservation);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _reservationsService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> ReservationExists(int id)
        {
            var reservation = await _reservationsService.GetByIdAsync(id);
            return reservation != null;
        }
    }
}

