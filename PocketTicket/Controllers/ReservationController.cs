using Microsoft.AspNetCore.Mvc;

namespace PocketTicket.Controllers
{
    public class ReservationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
