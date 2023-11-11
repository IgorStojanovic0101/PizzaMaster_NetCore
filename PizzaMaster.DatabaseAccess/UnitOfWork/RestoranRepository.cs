using Microsoft.EntityFrameworkCore;
using PizzaMaster.Application.Repositories;
using PizzaMaster.DataAccess.EF;
using PizzaMaster.Domain.Entities;

namespace PizzaMaster.DataAccess.UnitOfWork
{
    public class RestoranRepository : Repository<Restoran>, IRestoranRepository
    {
        private ApplicationDbContext _db;
        public RestoranRepository(ApplicationDbContext db) : base(db) => _db = db;


        public Task<bool> UpdateRestoran(string email)
        {

            _db.Restorans.ToList().ForEach(customer => { });

            return Task.FromResult(true);
        }



        //public List<Restoran> GetAllRestorans()
        //{

        //    var restorans = this._db.Restorans.ToList();

        //    return restorans;
        //}


    }
}
