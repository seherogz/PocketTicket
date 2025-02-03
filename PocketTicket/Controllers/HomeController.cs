using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using PocketTicket.Models;
using PocketTicket.Data.Services;

namespace PocketTicket.Controllers;

public class HomeController : Controller
{
    private readonly IAirportsService _airportsService;

    public HomeController(IAirportsService airportsService)
    {
        _airportsService = airportsService;
    }

    public async Task<IActionResult> Index()
    {
        var airports = await _airportsService.GetAllAsync(); // Havalimanlar?n? al?yoruz
        return View(airports); // Havalimanlar? model olarak view'e gönderiliyor
    }
}
