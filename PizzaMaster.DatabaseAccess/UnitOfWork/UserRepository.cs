using PizzaMaster.Application.Repositories;
using PizzaMaster.Data;
using PizzaMaster.DataAccess.EF;
using PizzaMaster.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaMaster.DataAccess.UnitOfWork
{

    public class UserRepository : Repository<User>, IUserRepository
    {
        private ApplicationDbContext _db;
        public UserRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public Task<bool> UpdateUser(string email)
        {

            _db.Users.ToList().ForEach(customer => { });

            return Task.FromResult(true);
        }

        public List<User> GetAllUsers()
        {

            var models = _db.Users.ToList();

            return models;
        }


    }
}
