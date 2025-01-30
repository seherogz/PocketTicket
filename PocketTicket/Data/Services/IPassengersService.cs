using PocketTicket.Data.Base;
using PocketTicket.Models;
using System.Linq.Expressions;

namespace PocketTicket.Data.Services
{
    public interface IPassengersService : IEntityBaseRepository<Reservation>
    {
        Task IEntityBaseRepository<Reservation>.AddAsync(Reservation entity)
        {
            throw new NotImplementedException();
        }

        Task IEntityBaseRepository<Reservation>.DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Reservation>> IEntityBaseRepository<Reservation>.GetAllAsync()
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Reservation>> IEntityBaseRepository<Reservation>.GetAllAsync(params Expression<Func<Reservation, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        Task<Reservation> IEntityBaseRepository<Reservation>.GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task IEntityBaseRepository<Reservation>.UpdateAsync(Reservation entity)
        {
            throw new NotImplementedException();
        }
    }
}
