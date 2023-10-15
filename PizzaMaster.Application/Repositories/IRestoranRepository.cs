

using PizzaMaster.Domain;
using PizzaMaster.Domain.Entities;

namespace PizzaMaster.Application.Repositories
{
    public interface IRestoranRepository : IRepository<Restoran>
    {
        Task<bool> UpdateRestoran(string email);

    }
}
