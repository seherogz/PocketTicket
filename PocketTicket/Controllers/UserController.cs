using Microsoft.AspNetCore.Mvc;

namespace PocketTicket.Controllers;

public class UserController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
