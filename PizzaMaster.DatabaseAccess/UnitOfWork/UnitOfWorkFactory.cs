using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PizzaMaster.Application;
using PizzaMaster.DataAccess.EF;
using PizzaMaster.Domain.Entities;
using System.Data;

namespace PizzaMaster.DataAccess.UnitOfWork
{
    public class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        private readonly string _connectionString;
        public UnitOfWorkFactory(IConfiguration configuration) 
        {    
            this._connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public IUnitOfWork Create() => new UnitOfWork(
            new ApplicationDbContext(new DbContextOptionsBuilder<ApplicationDbContext>().UseSqlServer(_connectionString).Options),
            new SqlConnection(_connectionString));


    }
}
