using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PocketTicket.Data;
using PocketTicket.Data.Services;
using PocketTicket.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IAirportsService, AirportsService>(); // IAirportsService'? DI konteynerine ekliyoruz
builder.Services.AddScoped<IFlightsService, FlightService>();




builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
.AddEntityFrameworkStores<AppDbContext>()
.AddDefaultTokenProviders();

builder.Services.AddMemoryCache();
builder.Services.AddSession();
builder.Services.AddAuthentication(option =>
{
    option.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;

});




// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer("Data Source=SEHEROUZFDCC\\SQLEXPRESS;Initial Catalog=PocketTicket;Integrated Security=True;Pooling=False;Encrypt=True;Trust Server Certificate=True "));



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseAuthentication();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


AppDbInitializer.Seed(app);
AppDbInitializer.SeedUsersAndRolesAsync(app).GetAwaiter().GetResult();

app.Run();
