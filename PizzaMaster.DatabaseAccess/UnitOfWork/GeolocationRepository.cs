using MongoDB.Bson;
using MongoDB.Driver;
using PizzaMaster.Application.Repositories;
using PizzaMaster.Infrastructure.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaMaster.DataAccess.UnitOfWork
{
    public class GeolocationRepository : IGeolocationRepository
    {
        private readonly IMongoDatabase _mongoDatabase;
        private IMongoCollection<BsonDocument> _kretanjeDostavljaca;
        public GeolocationRepository(IMongoDatabase mongoDatabase) 
        {
            _mongoDatabase = mongoDatabase;
            _kretanjeDostavljaca = this._mongoDatabase.GetCollection<BsonDocument>(MongoCollections.KretanjeDostavljaca);

        }

        public string GetGeolocation(double longitude, double latitude)
        {

            var documents = _kretanjeDostavljaca.Find(new BsonDocument()).ToList();

            return "address";

        }
    }
}
