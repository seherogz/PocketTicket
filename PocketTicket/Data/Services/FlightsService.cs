using Microsoft.EntityFrameworkCore;
using PocketTicket.Data;
using PocketTicket.Data.Base;
using PocketTicket.Models;
using PocketTicket.ViewModel;
using PocketTicket.ViewModels;
using System.Threading.Tasks;

namespace PocketTicket.Data.Services
{
    public class FlightService : EntityBaseRepository<Flight>, IFlightsService
    {
        private readonly AppDbContext _context;

        public FlightService(AppDbContext context) : base(context)
        {
            _context = context;
        }

        // Uçuşun detaylarını ID'ye göre almak için
        public async Task<Flight> GetByIdAsync(int id)
        {
            var flightDetails = await _context.Flights
                .Include(f => f.DepartureAirport)  // Kalkış havalimanı bilgisi
                .Include(f => f.ArrivalAirport)    // Varış havalimanı bilgisi
                .FirstOrDefaultAsync(f => f.Id == id); // Verilen ID'ye sahip uçuşu getirir

            return flightDetails;
        }

        // Yeni uçuş eklemek için
        public async Task AddAsync(FlightVM flightVM)
        {
            var newFlight = new Flight()
            {
                Airline = flightVM.Airline,
                FlightNumber = flightVM.FlightNumber,
                DepartureTime = flightVM.DepartureTime,
                ArrivalTime = flightVM.ArrivalTime,
                Price = flightVM.Price,
                DepartureAirportId = flightVM.DepartureAirportId,
                ArrivalAirportId = flightVM.ArrivalAirportId
            };

            await _context.Flights.AddAsync(newFlight); // Yeni uçuşu ekle
            await _context.SaveChangesAsync(); 

        }

        // Uçuşu güncellemek için
        public async Task UpdateAsync(FlightVM flightVM)
        {
            var existingFlight = await _context.Flights.FirstOrDefaultAsync(f => f.Id == flightVM.Id);

            if (existingFlight != null)
            {
                existingFlight.Id = flightVM.Id;
                existingFlight.Airline = flightVM.Airline;
                existingFlight.FlightNumber = flightVM.FlightNumber;
                existingFlight.DepartureTime = flightVM.DepartureTime;
                existingFlight.ArrivalTime = flightVM.ArrivalTime;
                existingFlight.Price = flightVM.Price;
                existingFlight.Status = flightVM.Status;
                existingFlight.DepartureAirportId = flightVM.DepartureAirportId;
                existingFlight.ArrivalAirportId = flightVM.ArrivalAirportId;

                await _context.SaveChangesAsync();
            }
        }

        // Uçuşu silme
        public async Task DeleteAsync(int id)
        {
            var flight = await _context.Flights.FindAsync(id); // Verilen ID'ye sahip uçuşu bul

            if (flight != null)
            {
                _context.Flights.Remove(flight); // Uçuşu sil
                await _context.SaveChangesAsync();
            }
        }

        // Uçuşlar için dropdown verilerini alma
        public async Task<FlightDropdowns> GetFlightDropdownsValuesAsync()
        {
            var response = new FlightDropdowns()
            {
                Airports = await _context.Airports.OrderBy(a => a.Name).ToListAsync(),
            };

            return response;
        }
    }
}
