

using PizzaMaster.Domain.Entities;
using PizzaMaster.Domain;

namespace PizzaMaster.Application.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<bool> UpdateUser(string email);

        List<User> GetAllUsers();

        void LogUser(string username, string password);

    }
}
