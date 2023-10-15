using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using PizzaMaster.Application;

namespace PizzaMaster.Data.SQLConnection
{
    public class SqlConnectionFactory : ISqlConnectionFactory
    {
        private readonly IConfiguration _configuration;

        public SqlConnectionFactory(IConfiguration configuration) => _configuration = configuration;
        public IDbConnection Create() => new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
        

    }
}
