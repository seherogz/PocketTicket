using PocketTicket.Data.Base;
using PocketTicket.Models;

namespace PocketTicket.Data.Services;

public class PassengersService : EntityBaseRepository<Passenger>, IPassengersService//bu class dbcontext e bağımlı
{
    readonly AppDbContext _context;

    public PassengersService(AppDbContext context) : base(context)

    {
        _context = context;
    }
}
