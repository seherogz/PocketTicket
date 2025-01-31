using PocketTicket.Data.Base;
using PocketTicket.Models;
using System.Linq.Expressions;

namespace PocketTicket.Data.Services
{
    public interface IReservationsService : IEntityBaseRepository<Reservation>
    {
      
    }
}
