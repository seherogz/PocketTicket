using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PocketTicket.Data.Static;
using PocketTicket.Data;
using PocketTicket.Models;
using PocketTicket.Data;
using PocketTicket.Data.Static;
using PocketTicket.Models;
using PocketTicket.ViewModels;

namespace PocketTicket.Controllers;

public class AccountController : Controller
{
    readonly UserManager<ApplicationUser> _userManager;
    readonly SignInManager<ApplicationUser> _signInManager;
    readonly AppDbContext _context;

    public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, AppDbContext context)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _context = context;
    }

    public IActionResult Login()
    {
        return View(new LoginVM());
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginVM login)
    {
        if (!ModelState.IsValid) return View(login);

        var user = await _userManager.FindByEmailAsync(login.EmailAdress); //emailin database'de var olup olmadğına baktık

        if (user is not null)
        {
            var passwordCheck = await _userManager.CheckPasswordAsync(user, login.Password);
            if (passwordCheck)
            {
                var result = await _signInManager.PasswordSignInAsync(user, login.Password, false, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "HomePage"); //login olursa başarılı şekilde bu sayfaya gönderir.
                }

            }
            TempData["Error"] = "Wrong password"; //eğer başarılı şekilde giriş yapamazsak , bir kere okunduğu zaman kendi kendini yok eder.
            return View(login);
        }

        TempData["Error"] = "Wrong login";
        return View(login);

    }

    public IActionResult Register() => View(new RegisterVM());

    [HttpPost]
    public async Task<IActionResult> Register(RegisterVM register)
    {
        if (!ModelState.IsValid) return View(register);

        var user = await _userManager.FindByEmailAsync(register.EmailAddress);

        if (user is not null)
        {
            TempData["Error"] = "This email address is already in use";
            return View(register);
        }

        var newUser = new ApplicationUser()
        {
            Email = register.EmailAddress,
            FullName = register.FullName,
            UserName = register.FullName,
            EmailConfirmed = true
        };

        var response = await _userManager.CreateAsync(newUser, register.Password);

        if (response.Succeeded)
        {

            await _userManager.AddToRoleAsync(newUser, UserRoles.User);
            return View("RegisterCompleted");
        }

        return View(register);
    }

    [HttpPost]
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Index", "HomePage");
    }
}





