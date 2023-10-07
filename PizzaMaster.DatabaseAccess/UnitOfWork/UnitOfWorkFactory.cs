using DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace WebAPI
{
    public class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        private readonly string _connectionString;



        public UnitOfWorkFactory(string connectionString) => _connectionString = connectionString;


        public IUnitOfWork Create() => new UnitOfWork(new ApplicationDbContext(new DbContextOptionsBuilder<ApplicationDbContext>().UseSqlServer(_connectionString).Options));
        

    }
}
