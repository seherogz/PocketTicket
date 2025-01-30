using Microsoft.AspNetCore.Mvc;
using PocketTicket.Models;
using PocketTicket.Data.Services;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace PocketTicket.Controllers
{
    public class AirportController : Controller
    {
        private readonly IAirportsService _airportsService;

        public AirportController(IAirportsService airportsService)
        {
            _airportsService = airportsService;
        }

        public async Task<IActionResult> Index()
        {
            var airports = await _airportsService.GetAllAsync();
            return View(airports); // List of airports view
        }

        public async Task<IActionResult> Details(int id)
        {
            var airport = await _airportsService.GetByIdAsync(id);
            if (airport == null)
            {
                return View("_NotFound");
            }
            return View(airport);
        }

        public IActionResult Create()
        {
            return View(); 
        }

        [HttpPost]
        public async Task<IActionResult> Create(Airport airport)
        {
            if (ModelState.IsValid)
            {
                await _airportsService.AddAsync(airport);
                return RedirectToAction(nameof(Index));
            }

            return View(airport);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var airport = await _airportsService.GetByIdAsync(id);
            if (airport == null)
            {
                return View("_NotFound");
            }
            return View(airport); 
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Airport airport)
        {
            if (ModelState.IsValid)
            {
                await _airportsService.UpdateAsync(airport);
                return RedirectToAction(nameof(Index));
            }

            return View(airport);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var airport = await _airportsService.GetByIdAsync(id);
            if (airport == null)
            {
                return View("_NotFound");
            }
            return View(airport);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _airportsService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Filter(string searchString)
        {
            if (string.IsNullOrEmpty(searchString))
            {
                return RedirectToAction(nameof(Index));
            }

            var airports = await _airportsService.SearchByNameAsync(searchString);
            return View("Index", airports); // Display the search result
        }
    }
}

