using PocketTicket.Data.Base;
using PocketTicket.Models;
using System.Linq.Expressions;

namespace PocketTicket.Data.Services
{
    public interface IPassengersService : IEntityBaseRepository<Passenger>
    {
        Task<IEnumerable<Passenger>> GetAllAsync();
        Task<Passenger> GetByIdAsync(int id);
        Task AddAsync(Passenger passenger);
        Task UpdateAsync(Passenger passenger);
        Task DeleteAsync(int id);
        Task DeleteAsync(Passenger passenger);
    }
}