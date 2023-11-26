

using PizzaMaster.Domain;
using PizzaMaster.Domain.Entities;

namespace PizzaMaster.Application.Repositories
{
    public interface IRestoranRepository : IRepository<Restoran>
    {
         List<Restoran> GetAll(string[]? includes = null);
    }
}
