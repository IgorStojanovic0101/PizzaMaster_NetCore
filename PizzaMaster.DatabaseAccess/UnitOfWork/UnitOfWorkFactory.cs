using Microsoft.AspNetCore.Hosting;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using MongoDB.Driver;
using MongoDB.Driver.Core.Configuration;
using Neo4jClient;
using PizzaMaster.Application;
using PizzaMaster.DataAccess.EF;
using PizzaMaster.DataAccess.Mongo;
using PizzaMaster.DataAccess.Neo4j;
using PizzaMaster.Domain.Entities;
using System.Data;

namespace PizzaMaster.DataAccess.UnitOfWork
{
    public class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        private readonly string _sqlConnectionString;
        private readonly string _mongoConnectionString;
        private readonly string _neo4jConnectionString;
        public UnitOfWorkFactory(IConfiguration configuration, IWebHostEnvironment environment) 
        {    
            this._sqlConnectionString = environment.IsDevelopment() ? configuration.GetConnectionString("DefaultConnection") : configuration.GetSection("ProdConnection").Value;
            this._mongoConnectionString = environment.IsDevelopment() ? configuration.GetConnectionString("MongoDB"): configuration.GetSection("MongoDB").Value;

        }

        public IUnitOfWork Create() => new UnitOfWork(
            new ApplicationDbContext(new DbContextOptionsBuilder<ApplicationDbContext>().UseSqlServer(_sqlConnectionString).Options),
            new SqlConnection(_sqlConnectionString)

            );
        public IMongoUnitOfWork CreateMongo()
        {
            return new MongoUnitOfWork(new MongoClient(_mongoConnectionString).GetDatabase("pizzamaster"));
        }
        public INeo4jUnitOfWork CreateNeo4j()
        {
            return new Neo4jUnitOfWork(new GraphClient(new Uri(_neo4jConnectionString)));
        }


    }
}
