using PocketTicket.Data.Base;
using PocketTicket.Data.Services;
using PocketTicket.Data;
using Microsoft.EntityFrameworkCore;

public class PassengersService : EntityBaseRepository<Passenger>, IPassengersService
{
    readonly AppDbContext _context;

    public PassengersService(AppDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Passenger>> GetAllAsync()
    {
        return await _context.Passengers.ToListAsync();
    }

    public async Task<Passenger> GetByIdAsync(int id)
    {
        return await _context.Passengers.FindAsync(id);
    }

    public async Task AddAsync(Passenger passenger)
    {
        await _context.Passengers.AddAsync(passenger);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Passenger passenger)
    {
        _context.Passengers.Update(passenger);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Passenger passenger)
    {
        _context.Passengers.Remove(passenger);
        await _context.SaveChangesAsync();
    }
}
