using Dapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PizzaMaster.Application;
using PizzaMaster.Application.Repositories;
using PizzaMaster.DataAccess.EF;
using PizzaMaster.Domain.Entities;
using System.Data;
using System.Linq.Expressions;

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

      
        public override List<Restoran> GetAll(IEnumerable<(Expression<Func<Restoran, object>> NavigationProperty, string[] ChildProperties)>? includes = null)
        {
            
            string query = "SELECT * FROM Restorans";
            var dapperResult = _dbConnection.Query<Restoran>(query).ToList();


            return dapperResult;
        }

        public override Restoran SingleOrDefault(Expression<Func<Restoran, bool>> expression, string[]? includes = null)
        {
            // Use Dapper to execute a SQL query
            string query = $"SELECT * FROM Restorans WHERE {GetSqlExpression(expression)}";
            var dapperResult = _dbConnection.QuerySingleOrDefault<Restoran>(query);

            // If using 'includes' from the base method, you may need to handle it accordingly

            return dapperResult;
        }

        // Helper method to convert LINQ expression to SQL string (you might need to adapt this based on your needs)
       
        private string GetSqlExpression(Expression<Func<Restoran, bool>> expression)
        {
            var binaryExpression = (BinaryExpression)expression.Body;

            var left = binaryExpression.Left;
            var right = binaryExpression.Right;

            var memberExpression = left as MemberExpression;
            var constantExpression = right as ConstantExpression;

            if (memberExpression != null && constantExpression != null)
            {
                return $"{memberExpression.Member.Name} = '{constantExpression.Value}'";
            }

            // Handle other cases as needed

            throw new InvalidOperationException("Unsupported expression type");

            // Handle other cases as needed
        }

    }
}
