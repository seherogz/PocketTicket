using PocketTicket.Data.Base;
using PocketTicket.Models;
using PocketTicket.ViewModel;

namespace PocketTicket.Data.Services;

public interface IFlightsService : IEntityBaseRepository<Flight>
{
  
        Task<IEnumerable<Flight>> GetAllAsync();
        Task<Flight> GetByIdAsync(int id);
        Task AddAsync(Flight flight);
        Task UpdateAsync(Flight flight);
        Task DeleteAsync(int id);
        Task<FlightDropdowns> GetFlightDropdownsValuesAsync();

}
