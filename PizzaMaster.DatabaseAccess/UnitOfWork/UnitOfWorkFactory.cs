using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PizzaMaster.Application;
using PizzaMaster.Data.EF;

namespace PizzaMaster.DatabaseAccess.UnitOfWork
{
    public class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        private readonly string _connectionString;



        public UnitOfWorkFactory(string connectionString) => _connectionString = connectionString;


        public IUnitOfWork Create() => new UnitOfWork(new ApplicationDbContext(new DbContextOptionsBuilder<ApplicationDbContext>().UseSqlServer(_connectionString).Options));
        

    }
}
