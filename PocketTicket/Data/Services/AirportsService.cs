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
}