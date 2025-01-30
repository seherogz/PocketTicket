using PocketTicket.Data.Base;
using PocketTicket.Models;
using System.Linq.Expressions;

namespace PocketTicket.Data.Services
{
    public interface IReservationsService : IEntityBaseRepository<Reservation>
    {
        public Task AddAsync(Reservation entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Reservation>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Reservation>> GetAllAsync(params Expression<Func<Reservation, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public Task<Reservation> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Reservation entity)
        {
            throw new NotImplementedException();
        }
    }
}
