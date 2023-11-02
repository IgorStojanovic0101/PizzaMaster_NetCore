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
    public class PizzaTypeRepository : Repository<PizzaType>, IPizzaTypeRepository
    {
        private ApplicationDbContext _db;
        public PizzaTypeRepository(ApplicationDbContext db) : base(db) => this._db = db;
    
    }
}
