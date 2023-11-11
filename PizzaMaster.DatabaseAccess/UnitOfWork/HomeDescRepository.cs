using PizzaMaster.Application.Repositories;
using PizzaMaster.DataAccess.EF;
using PizzaMaster.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaMaster.DataAccess.UnitOfWork;

public class HomeDescRepository : Repository<HomeDesc>, IHomeDescRepository
{
    private ApplicationDbContext _db;
    public HomeDescRepository(ApplicationDbContext db) : base(db) => _db = db;
}
