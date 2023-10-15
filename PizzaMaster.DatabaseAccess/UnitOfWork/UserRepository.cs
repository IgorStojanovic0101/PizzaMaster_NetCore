
using PizzaMaster.Application.Repositories;
using PizzaMaster.Data;
using PizzaMaster.Data.EF;
using PizzaMaster.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaMaster.DatabaseAccess.UnitOfWork
{
   
    public class UserRepository : Repository<User>, IUserRepository
    {
        private ApplicationDbContext _db;
        public UserRepository(ApplicationDbContext db) : base(db)
        {
            this._db = db;
        }

        public Task<bool> UpdateUser(string email)
        {

            this._db.Users.ToList().ForEach(customer => { });

            return Task.FromResult(true);
        }

        public List<User> GetAllUsers()
        {

           var models = this._db.Users.ToList();

            return models;
        }


    }
}
