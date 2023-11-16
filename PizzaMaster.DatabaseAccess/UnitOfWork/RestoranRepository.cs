using Dapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PizzaMaster.Application;
using PizzaMaster.Application.Repositories;
using PizzaMaster.DataAccess.EF;
using PizzaMaster.Domain.Entities;
using System.Data;

namespace PizzaMaster.DataAccess.UnitOfWork
{
    public class RestoranRepository : Repository<Restoran>, IRestoranRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IDbConnection _dbConnection;

        public RestoranRepository(ApplicationDbContext dbContext, IDbConnection dbConnection) : base(dbContext)
        {
            _dbContext = dbContext;
            _dbConnection = dbConnection;

        }

        public List<Restoran> GetSomeProperties_DPR()
        {          
            Restoran restoran = new Restoran();

            string query = $"SELECT {nameof(restoran.RestoranIme)} FROM Restorans";

            return _dbConnection.Query<Restoran>(query).ToList();

        }
    }
}
