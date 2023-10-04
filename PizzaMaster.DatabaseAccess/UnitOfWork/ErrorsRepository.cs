using DataAccess;
using Models.Models;
using PizzaMaster.DatabaseAccess.UnitOfWork.IRepositories;
using PizzaMaster.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI;

namespace PizzaMaster.DatabaseAccess.UnitOfWork
{
    public class ErrorsRepository : Repository<ErrorModel>, IErrorsRepository
    {
        private ApplicationDbContext _db;
        public ErrorsRepository(ApplicationDbContext db) : base(db)
        {
            this._db = db;
        }

        public Task<bool> UpdateRestoran(string email)
        {

            this._db.Restorans.ToList().ForEach(customer => { });

            return Task.FromResult(true);
        }


    }
}
