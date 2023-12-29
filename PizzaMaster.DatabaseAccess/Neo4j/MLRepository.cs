using Neo4jClient;
using PizzaMaster.Application.Repositories;
using PizzaMaster.Domain.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaMaster.DataAccess.Neo4j
{
    public class MLRepository : Neo4jRepository<UserNode>, IMLRepository
    {
        private readonly IGraphClient _client;

        public MLRepository(IGraphClient client) : base(client) => this._client = client;
    }
}
