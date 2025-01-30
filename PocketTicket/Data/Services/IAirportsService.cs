using PocketTicket.Data.Base;
using PocketTicket.Models;
using System.Linq.Expressions;

namespace PocketTicket.Data.Services
{
    public interface IAirportsService : IEntityBaseRepository<Airport>
    {
        Task<IEnumerable<Airport>> GetAllAsync();

        Task<Airport> GetByIdAsync(int id);

        Task AddAsync(Airport airport);

        Task UpdateAsync(Airport airport);

        Task DeleteAsync(int id);

        Task<IEnumerable<Airport>> SearchByNameAsync(string name); //Arama yapılır
    }
}
