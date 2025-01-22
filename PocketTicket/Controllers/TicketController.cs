using Microsoft.AspNetCore.Mvc;

namespace PocketTicket.Controllers
{
    public class TicketController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
