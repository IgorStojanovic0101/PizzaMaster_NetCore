using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaMaster.Application
{
    public interface INeo4jRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<long> CreateAsync(T entity);
        Task UpdateAsync(int id, T updatedEntity);
        Task DeleteAsync(int id);
    }
}
