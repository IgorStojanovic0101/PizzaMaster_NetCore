

using PizzaMaster.Domain;
using PizzaMaster.Domain.Entities;

namespace PizzaMaster.Application.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<bool> UpdateUser(string email);

        List<User> GetAllUsers();
    }
}
