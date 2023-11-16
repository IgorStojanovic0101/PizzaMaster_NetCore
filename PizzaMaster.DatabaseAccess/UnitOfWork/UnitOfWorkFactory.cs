using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using MongoDB.Driver.Core.Configuration;
using PizzaMaster.Application;
using PizzaMaster.DataAccess.EF;
using PizzaMaster.Domain.Entities;
using System.Data;

namespace PizzaMaster.DataAccess.UnitOfWork
{
    public class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        private readonly string _sqlConnectionString;
        private readonly string _mongoConnectionString;
        public UnitOfWorkFactory(IConfiguration configuration) 
        {    
            this._sqlConnectionString = configuration.GetConnectionString("DefaultConnection");
            this._mongoConnectionString = configuration.GetConnectionString("MongoDB");

        }

        public IUnitOfWork Create() => new UnitOfWork(
            new ApplicationDbContext(new DbContextOptionsBuilder<ApplicationDbContext>().UseSqlServer(_sqlConnectionString).Options),
            new SqlConnection(_sqlConnectionString),
            new MongoClient(_mongoConnectionString).GetDatabase("pizzamaster")
          
            );


    }
}
