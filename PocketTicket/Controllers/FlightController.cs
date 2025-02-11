using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PocketTicket.Data.Services;
using PocketTicket.Models;
using PocketTicket.ViewModel;
using System.Linq;
using System.Threading.Tasks;

namespace PocketTicket.Controllers;

public class FlightController : Controller
{
    private readonly IFlightsService _service;

    public FlightController(IFlightsService service)
    {
        _service = service;
    }

    public async Task<IActionResult> Index()
    {
        var flights = await _service.GetAllAsync();
        var dropdowns = await _service.GetFlightDropdownsValuesAsync();
        ViewBag.Airports = dropdowns.Airports;

        return View(flights);
    }

    public async Task<IActionResult> Details(int id)
    {
        var flightDetail = await _service.GetByIdAsync(id);
        if (flightDetail == null) return View("_NotFound");
        return View(flightDetail);
    }
    public async Task<IActionResult> Create()
    {
        var dropdowns = await _service.GetFlightDropdownsValuesAsync();
        ViewBag.Airports = new SelectList(dropdowns.Airports, "Id", "Name");
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Flight flight)
    {
        if (!ModelState.IsValid)
        {
            var dropdowns = await _service.GetFlightDropdownsValuesAsync();
            ViewBag.Airports = new SelectList(dropdowns.Airports, "Id", "Name");
            return View(flight);
        }
        await _service.AddAsync(flight);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int id)
    {
        var existingFlight = await _service.GetByIdAsync(id);
        if (existingFlight == null)
        {
            return View("_NotFound"); 
        }

        var response = new FlightVM()
        {
            Id = existingFlight.Id,
            Airline = existingFlight.Airline,
            FlightNumber = existingFlight.FlightNumber,
            DepartureTime = existingFlight.DepartureTime,
            ArrivalTime = existingFlight.ArrivalTime,
            Price = existingFlight.Price,
            Status = existingFlight.Status,
            DepartureAirportId = existingFlight.DepartureAirportId,
            ArrivalAirportId = existingFlight.ArrivalAirportId,
        };

        var flightDropdowns = await _service.GetFlightDropdownsValuesAsync();

        ViewBag.DepartureAirports = new SelectList(flightDropdowns.Airports, "Id", "Name");
        ViewBag.ArrivalAirports = new SelectList(flightDropdowns.Airports, "Id", "Name");

        return View(response);
    }


    [HttpPost]
    [HttpPost]
    public async Task<IActionResult> Edit(FlightVM flight)
    {
        if (flight.Id == 0)
        {
            return View("_NotFound");
        }

        if (!ModelState.IsValid)
        {
            return View(flight);
        }

        // FlightVM'yi Flight'a dönüştür
        var flightModel = new Flight
        {
            Id = flight.Id,
            Airline = flight.Airline,
            FlightNumber = flight.FlightNumber,
            DepartureTime = flight.DepartureTime,
            ArrivalTime = flight.ArrivalTime,
            Price = flight.Price,
            Status = flight.Status,
            DepartureAirportId = flight.DepartureAirportId,
            ArrivalAirportId = flight.ArrivalAirportId
        };

        // Flight modelini güncelle
        await _service.UpdateAsync(flightModel);

        return RedirectToAction(nameof(Index));
    }


    public async Task<IActionResult> Filter(int? departureAirportId, int? arrivalAirportId)
    {
        var allFlights = await _service.GetAllAsync();

        if (departureAirportId.HasValue && arrivalAirportId.HasValue)
        {
            var filteredFlights = allFlights.Where(f => f.DepartureAirportId == departureAirportId.Value &&
                                                        f.ArrivalAirportId == arrivalAirportId.Value)
                                            .ToList();

            if (filteredFlights.Any())
            {
                return View("Index", filteredFlights);
            }
            else
            {
                ViewBag.Message = "Seçtiğiniz kalkış ve varış noktaları için uçuş bulunamadı.";
                return View("Index", new List<Flight>()); 
            }
        }

        return RedirectToAction(nameof(Index)); // Eğer giriş yoksa tüm uçuşları göster
    }





    public async Task<IActionResult> Delete(int id)
    {
        var flightDetail = await _service.GetByIdAsync(id);
        if (flightDetail == null) return View("_NotFound");
        return View(flightDetail);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _service.DeleteAsync(id);
        return RedirectToAction(nameof(Index));
    }
}
