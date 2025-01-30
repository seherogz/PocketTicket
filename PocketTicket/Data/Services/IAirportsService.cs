using PocketTicket.Data.Base;
using PocketTicket.Models;
using System.Linq.Expressions;

namespace PocketTicket.Data.Services
{
    public interface IAirportsService : IEntityBaseRepository<Airport>
    {
        public Task AddAsync(Airport entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Airport>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Airport>> GetAllAsync(params Expression<Func<Airport, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public Task<Airport> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Airport entity)
        {
            throw new NotImplementedException();
        }
    }
}
