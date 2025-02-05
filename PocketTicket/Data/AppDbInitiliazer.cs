using Microsoft.AspNetCore.Identity;
using PocketTicket.Data.Static;
using PocketTicket.Models;

namespace PocketTicket.Data;

public class AppDbInitializer
{
    public static void Seed(IApplicationBuilder applicationBuilder)
    {
        using var serviceScope = applicationBuilder.ApplicationServices.CreateScope();
        var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

        context.Database.EnsureCreated();

        if (!context.Airports.Any())
        {
            context.Airports.AddRange(
                new List<Airport>()
                {
            new Airport()
            {
                Name = "SkyLine Airways",
                Desc = "Reliable international flights.",
                Logo = "http://example.com/images/airlines/skyline.jpg"
            },
            new Airport()
            {
                Name = "AirBlue",
                Desc = "Affordable domestic flights.",
                Logo = "http://example.com/images/airlines/airblue.jpg"
            },
            new Airport()
            {
                Name = "Golden Wings",
                Desc = "Luxury flying experience.",
                Logo = "http://example.com/images/airlines/goldenwings.jpg"
            },
            new Airport()
            {
                Name = "Air Express",
                Desc = "Fast and convenient air travel.",
                Logo = "http://example.com/images/airlines/airexpress.jpg"
            },
            new Airport()
            {
                Name = "Oceanic Airways",
                Desc = "Global connections with excellent service.",
                Logo = "http://example.com/images/airlines/oceanic.jpg"
            },
            new Airport()
            {
                Name = "SkyHigh Airlines",
                Desc = "Premium service for elite travelers.",
                Logo = "http://example.com/images/airlines/skyhigh.jpg"
            }
                });
            context.SaveChanges();

        }





        if (!context.Flights.Any())
            {
                context.Flights.AddRange(
                    new List<Flight>()
                    {
                    new Flight()
                    {
                        FlightNumber = "SK123",
                        DepartureAirportId = 1,
                        ArrivalAirportId = 2,
                        DepartureTime = DateTime.Now.AddHours(3),
                        ArrivalTime = DateTime.Now.AddHours(5),
                        Price = 150,
                        Status = FlightStatus.Delayed,
                    },
                    new Flight()
                    {
                        FlightNumber = "AB456",
                        DepartureAirportId = 1,
                        ArrivalAirportId = 3,
                        DepartureTime = DateTime.Now.AddHours(2),
                        ArrivalTime = DateTime.Now.AddHours(4),
                        Price = 120,
                        Status = FlightStatus.OnTime,
                    },
                    new Flight()
                    {
                        FlightNumber = "GW789",
                        DepartureAirportId = 3,
                        ArrivalAirportId = 2,
                        DepartureTime = DateTime.Now.AddHours(10),
                        ArrivalTime = DateTime.Now.AddHours(14),
                        Price = 500,
                        Status = FlightStatus.OnTime,
                    },
                    new Flight()
                    {
                        FlightNumber = "LH234",
                        DepartureAirportId = 2,
                        ArrivalAirportId = 4,
                        DepartureTime = DateTime.Now.AddHours(6),
                        ArrivalTime = DateTime.Now.AddHours(9),
                        Price = 200,
                        Status = FlightStatus.OnTime,
                    },
                    new Flight()
                    {
                        FlightNumber = "KL567",
                        DepartureAirportId = 3,
                        ArrivalAirportId = 1,
                        DepartureTime = DateTime.Now.AddHours(8),
                        ArrivalTime = DateTime.Now.AddHours(12),
                        Price = 300,
                        Status = FlightStatus.Cancelled,
                    },
                    new Flight()
                    {
                        FlightNumber = "QR890",
                        DepartureAirportId = 4,
                        ArrivalAirportId = 2,
                        DepartureTime = DateTime.Now.AddHours(12),
                        ArrivalTime = DateTime.Now.AddHours(15),
                        Price = 400,
                        Status = FlightStatus.OnTime,
                    }


                    });
                context.SaveChanges();
            }

            if (!context.Passengers.Any())
            {
                context.Passengers.AddRange(
                    new List<Passenger>()
                    {
                    new Passenger() { FullName = "John Doe", Email = "john.doe@example.com", PhoneNumber="05467890345" },
                    new Passenger() { FullName = "Jane Smith", Email = "jane.smith@example.com", PhoneNumber="05497820125" },
                    new Passenger() { FullName = "Ali Veli", Email = "ali.veli@example.com", PhoneNumber="05360850315" }
                    });
                context.SaveChanges();
            }


            if (!context.Reservations.Any())
            {
                context.Reservations.AddRange(
                    new List<Reservation>()
                    {
            new Reservation()
            {
                ReservationDate = DateTime.Now,
                TotalPrice = 500.00m,
                PassengerId = 1,  // Daha önce eklediğiniz yolcunun id'si
                FlightId = 1
            },
            new Reservation()
            {
                ReservationDate = DateTime.Now,
                TotalPrice = 360.00m,
                PassengerId = 2,  // 2. yolcu
                FlightId = 2      // 2. uçuş
            },
            new Reservation()
            {
                ReservationDate = DateTime.Now,
                TotalPrice = 1000.00m,
                PassengerId = 3,  // 3. yolcu
                FlightId = 3      // 3. uçuş
            }
                    });
                context.SaveChanges();
            }

            if (!context.Tickets.Any())
            {
                context.Tickets.AddRange(
                    new List<Ticket>()
                    {
            new Ticket() { SeatNumber = "12A", TicketClass = "Economy", FlightId = 1,ReservationId = 1 },  // ReservationId burada belirlenmeli
            new Ticket() { SeatNumber = "15B", TicketClass = "Business", FlightId = 2, ReservationId = 2 },
            new Ticket() { SeatNumber = "18C", TicketClass = "Economy", FlightId = 3, ReservationId = 3 }
                    });
                context.SaveChanges();
            }

            if (!context.flight_Passengers.Any()) // Eğer Flight_Passenger tablosunda veri yoksa
            {
                var passengers = new List<Flight_Passenger>
            {
                new Flight_Passenger
                {
                    FlightId = 1,
                    PassengerId = 1,
                    TicketClass = "Economy",
                    SeatNumber = "12A"
                },
                new Flight_Passenger
                {
                    FlightId = 1,
                    PassengerId = 2,
                    TicketClass = "Business",
                    SeatNumber = "5B"
                },
                new Flight_Passenger
                {
                    FlightId = 2,
                    PassengerId = 3,
                    TicketClass = "First Class",
                    SeatNumber = "1A"
                }
            };

                context.flight_Passengers.AddRange(passengers); // Verileri ekleyin
                context.SaveChanges(); // Veritabanına kaydedin
            }
        }
    


    public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
    {
        using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
        {
            var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            // Roles
            if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
            if (!await roleManager.RoleExistsAsync(UserRoles.User))
                await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

            // Users
            var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            // Admin User
            string adminUserEmail = "admin@pocketticket.com";
            var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
            if (adminUser is null)
            {
                var newAdminUser = new ApplicationUser()
                {
                    FullName = "Admin User",
                    UserName = "admin-pocketticket",
                    Email = adminUserEmail,
                    EmailConfirmed = true
                };

                await userManager.CreateAsync(newAdminUser, "Admin@123");
                await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
            }

            // Regular User
            string appUserEmail = "user@pocketticket.com";
            var appUser = await userManager.FindByEmailAsync(appUserEmail);
            if (appUser is null)
            {
                var newAppUser = new ApplicationUser()
                {
                    FullName = "Regular User",
                    UserName = "user-pocketticket",
                    Email = appUserEmail,
                    EmailConfirmed = true
                };

                await userManager.CreateAsync(newAppUser, "User@123");
                await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
            }
        }
    }
}