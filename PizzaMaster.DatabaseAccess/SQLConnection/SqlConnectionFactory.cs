using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using PizzaMaster.Application;

namespace PizzaMaster.Data.SQLConnection
{
    public class SqlConnectionFactory : ISqlConnectionFactory
    {
        private readonly string _connectionString;
        public SqlConnectionFactory(string connectionString) => _connectionString = connectionString;
        public IDbConnection Create() => new SqlConnection(_connectionString);
        

    }
}
