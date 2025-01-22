using Microsoft.AspNetCore.Mvc;

namespace PocketTicket.Controllers
{
    public class FlightController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
