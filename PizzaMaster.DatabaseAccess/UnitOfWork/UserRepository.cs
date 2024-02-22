using Dapper;
using Microsoft.EntityFrameworkCore;
using PizzaMaster.Application.Repositories;
using PizzaMaster.DataAccess.EF;
using PizzaMaster.Domain.Entities;
using PizzaMaster.Domain.Enums;
using PizzaMaster.Infrastructure.System;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace PizzaMaster.DataAccess.UnitOfWork
{

    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IDbConnection _dbConnection;
        public UserRepository(ApplicationDbContext dbContext, IDbConnection dbConnection) : base(dbContext)
        {
            _dbContext = dbContext;
            _dbConnection = dbConnection;
        }

        public void LogUser(string username,string password)
        {
            var parameters = new
            {
                Username = username,
                Password = password
            };

            var result = _dbConnection.Query<ResultEnum>(StoredProcedures.spLogUsers, parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
           

        }
        public Task<bool> UpdateUser(string email)
        {

            _dbContext.Users.ToList().ForEach(customer => { });

            return Task.FromResult(true);
        }

        public List<User> GetAllUsers()
        {

            var models = _dbContext.Users.ToList();

            return models;
        }


    }
}
