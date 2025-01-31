using PocketTicket.Data.Base;
using PocketTicket.Models;

namespace PocketTicket.Data.Services
{
    public class TicketsService : EntityBaseRepository<Ticket>, ITicketsService//bu class dbcontext e bağımlı
    {
        readonly AppDbContext _context;

        public TicketsService(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
