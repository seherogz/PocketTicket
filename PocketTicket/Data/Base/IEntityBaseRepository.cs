using PocketTicket.Data.Base;
using System.Linq.Expressions;
using PocketTicket.Models;

namespace PocketTicket.Data.Base;

public interface IEntityBaseRepository<T> where T : class, IEntityBase, new() //T aslen bir class olacak.Ve IEntityBase'den miras almış olacak. o classtan bir obje alınabilir olacak. default olarak bir constructor vardır.
{
    Task<IEnumerable<T>> GetAllAsync();

    Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includeProperties);

    Task<T> GetByIdAsync(int id);

    Task AddAsync(T entity);

    Task UpdateAsync(T entity);

    Task DeleteAsync(int id);
}