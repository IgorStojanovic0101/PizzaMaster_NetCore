using DataAccess;
using Microsoft.EntityFrameworkCore;
using PizzaMaster.Models.DTOs;
using PizzaMaster.Models.Models;

namespace WebAPI
{
    public class RestoraniRepository : Repository<RestoranModel> , IRestoraniRepository
    {
        private ApplicationDbContext _db;
        public RestoraniRepository(ApplicationDbContext db) : base(db)
        {
            this._db = db;
        }

        public Task<bool> UpdateRestoran(string email)
        {

            this._db.Restorans.ToList().ForEach(customer => { });

            return Task.FromResult(true);
        }

        public List<RestoranModel> GetAllRestorans()
        {

            var restorans = this._db.Restorans.ToList();

            return restorans;
        }


    }
}
