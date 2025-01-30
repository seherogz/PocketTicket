using Microsoft.EntityFrameworkCore;
using PocketTicket.Data.Base;
using PocketTicket.Models;

namespace PocketTicket.Data.Services;

public class AirportsService : EntityBaseRepository<Airport>, IAirportsService//bu class dbcontext e bağımlı
{
    readonly AppDbContext _context;

    public AirportsService(AppDbContext context) : base(context)
                                                               
    {
        _context = context;
    }

    public async Task<IEnumerable<Airport>> GetAllAsync()
    {
        return await _context.Airports.ToListAsync();
    }

    public async Task<Airport> GetByIdAsync(int id)
    {
        return await _context.Airports
            .FirstOrDefaultAsync(a => a.Id == id);
    }

    public async Task AddAsync(Airport airport)
    {
        await _context.Airports.AddAsync(airport);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Airport airport)
    {
        _context.Airports.Update(airport);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var airport = await GetByIdAsync(id);
        if (airport != null)
        {
            _context.Airports.Remove(airport);
            await _context.SaveChangesAsync();
        }
    }
    public async Task<IEnumerable<Airport>> SearchByNameAsync(string name)
    {
        return await _context.Airports
            .Where(a => a.Name.Contains(name))
            .ToListAsync();
    }
}
}