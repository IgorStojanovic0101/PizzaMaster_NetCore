using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PizzaMaster.Application;
using PizzaMaster.DataAccess.EF;
using PizzaMaster.Domain.Entities;

namespace PizzaMaster.DataAccess.UnitOfWork
{
    public class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        private readonly IConfiguration _configuration;

        public UnitOfWorkFactory(IConfiguration configuration) => _configuration = configuration;

        public IUnitOfWork Create() => new UnitOfWork(new ApplicationDbContext(new DbContextOptionsBuilder<ApplicationDbContext>().UseSqlServer(_configuration.GetConnectionString("DefaultConnection")).Options));


    }
}
