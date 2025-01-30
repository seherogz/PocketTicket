using PocketTicket.Data.Base;
using PocketTicket.Models;

namespace PocketTicket.Data.Services
{
    public interface ITicketsService : IEntityBaseRepository<Ticket>
    {
    }
}
