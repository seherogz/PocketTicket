﻿using Microsoft.AspNetCore.Identity;
using PocketTicket.Data.Static;
using PocketTicket.Models;

namespace PocketTicket.Data;

public class AppDbInitializer
{
    public static void Seed(IApplicationBuilder applicationBuilder)
    {
        using var serviceScope = applicationBuilder.ApplicationServices.CreateScope();
        var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

        context.Database.EnsureCreated(); // Database oluşturulmamışsa oluştur.

        if (!context.Airports.Any())
        {
            context.Airports.AddRange(
                new List<Airport>()
                {
                    new Airport()
                    {
                        Name = "SkyLine Airways",
                        desc = "Reliable international flights.",
                        logo = "http://example.com/images/airlines/skyline.jpg"
                    },
                    new Airport()
                    {
                        Name = "AirBlue",
                        desc = "Affordable domestic flights.",
                        logo = "http://example.com/images/airlines/airblue.jpg"
                    },
                    new Airport()
                    {
                        Name = "Golden Wings",
                        desc = "Luxury flying experience.",
                        logo = "http://example.com/images/airlines/goldenwings.jpg"
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
                        DepartureAirportId = 3,
                        ArrivalAirportId = 4,
                        DepartureTime = DateTime.Now.AddHours(3),
                        ArrivalTime = DateTime.Now.AddHours(5),
                        Price = 150,
                        Status = FlightStatus.Delayed,
                    },
                    new Flight()
                    {
                        FlightNumber = "AB456",
                        DepartureAirportId = 1,
                        ArrivalAirportId = 2,
                        DepartureTime = DateTime.Now.AddHours(2),
                        ArrivalTime = DateTime.Now.AddHours(4),
                        Price = 120,
                        Status = FlightStatus.OnTime,
                    },
                    new Flight()
                    {
                        FlightNumber = "GW789",
                        DepartureAirportId = 2,
                        ArrivalAirportId = 5,
                        DepartureTime = DateTime.Now.AddHours(10),
                        ArrivalTime = DateTime.Now.AddHours(14),
                        Price = 500,
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

        if (!context.Tickets.Any())
        {
            context.Tickets.AddRange(
                new List<Ticket>()
                {
            new Ticket() { SeatNumber = "12A", TicketClass = "Economy", ReservationId = 1 },  // ReservationId burada belirlenmeli
            new Ticket() { SeatNumber = "15B", TicketClass = "Business", ReservationId = 2 },
            new Ticket() { SeatNumber = "18C", TicketClass = "Economy", ReservationId = 3 }
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
                FlightId = 1      // Daha önce eklediğiniz uçuşun id'si
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

