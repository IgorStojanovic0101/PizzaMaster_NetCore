using Neo4jClient;
using PizzaMaster.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaMaster.DataAccess.Neo4j
{
    public class Neo4jRepository<T> : INeo4jRepository<T> where T : class
    {
        private readonly IGraphClient _client;

        public Neo4jRepository(IGraphClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var query = _client.Cypher
                .Match($"(entity:{typeof(T).Name})")
                .Where($"ID(entity) = {id}")
                .Return(entity => new
                {
                    Entity = entity.As<T>(),
                    Neo4jId = entity.Id()
                });

            var result = await query.ResultsAsync;
            var entityResult = result?.FirstOrDefault();

            if (entityResult == null)
            {
                return default;
            }

            var idPropertyName = "Id"; // Replace with the actual name of your ID property
            var idProperty = entityResult.Entity.GetType().GetProperty(idPropertyName);

            if (idProperty != null)
            {
                idProperty.SetValue(entityResult.Entity, entityResult.Neo4jId);
            }

            return entityResult.Entity;
        }


        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _client.Cypher
                .Match($"(entity:{typeof(T).Name})")
                .Return(entity => entity.As<T>())
                .ResultsAsync;
        }

        public async Task<long> CreateAsync(T entity)
        {
            var result = await _client.Cypher
                .Create($"(entity:{typeof(T).Name} {{newEntity}})")
                .WithParam("newEntity", entity)
                .Return(entity => entity.Id())
                .ResultsAsync;

            return result.FirstOrDefault();
        }

        public async Task UpdateAsync(int id, T updatedEntity)
        {
            await _client.Cypher
                .Match($"(entity:{typeof(T).Name})")
                .Where($"ID(entity) = {id}")
                .Set("entity = {updatedEntity}")
                .WithParam("updatedEntity", updatedEntity)
                .ExecuteWithoutResultsAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await _client.Cypher
                .Match($"(entity:{typeof(T).Name})")
                .Where($"ID(entity) = {id}")
                .Delete("entity")
                .ExecuteWithoutResultsAsync();
        }
    }
}
