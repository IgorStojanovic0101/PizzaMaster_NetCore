using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaMaster.DatabaseAccess.SQLConnection
{
    public interface ISqlConnectionFactory
    {
        public IDbConnection Create();
    }
}
