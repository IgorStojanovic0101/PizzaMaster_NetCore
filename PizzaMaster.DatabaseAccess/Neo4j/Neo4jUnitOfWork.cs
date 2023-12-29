using Neo4jClient;
using PizzaMaster.Application;
using PizzaMaster.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaMaster.DataAccess.Neo4j
{
    public class Neo4jUnitOfWork : INeo4jUnitOfWork
    {
        private readonly IGraphClient _graphClient;

        public Neo4jUnitOfWork(IGraphClient graphClient)
        {
            _graphClient = graphClient;
            this.MLRepository = new MLRepository(graphClient);
        }

        public IMLRepository MLRepository { get; private set; }

    }
}
