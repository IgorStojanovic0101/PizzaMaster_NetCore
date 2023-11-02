using PizzaMaster.Application.Repositories;
using PizzaMaster.Data.EF;
using PizzaMaster.DatabaseAccess.UnitOfWork;
using PizzaMaster.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaMaster.Data.UnitOfWork
{
    internal class PastaTypeRepository : Repository<PastaType>, IPastaTypeRepository
    {
        private ApplicationDbContext _db;
        public PastaTypeRepository(ApplicationDbContext db) : base(db) => this._db = db;
    }
}
