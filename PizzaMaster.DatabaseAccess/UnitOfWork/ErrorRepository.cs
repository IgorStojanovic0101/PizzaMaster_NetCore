using PizzaMaster.Application.Repositories;
using PizzaMaster.Data.EF;
using PizzaMaster.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaMaster.DatabaseAccess.UnitOfWork
{
    public class ErrorRepository : Repository<Error>, IErrorRepository
    {

        public ErrorRepository(ApplicationDbContext db) : base(db)
        {      
        }

        


    }
}
