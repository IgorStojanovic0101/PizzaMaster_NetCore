using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.GeoJsonObjectModel;
using PizzaMaster.Application.Repositories;
using PizzaMaster.DataAccess.Mongo;
using PizzaMaster.Domain.Collections;
using PizzaMaster.Domain.Documents;
using PizzaMaster.Infrastructure.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaMaster.DataAccess.UnitOfWork
{
    public class GeolocationRepository : MongoRepository<GeoCollection>, IGeolocationRepository
    {
        private readonly IMongoDatabase _mongoDatabase;
        private IMongoCollection<LocationDocument> _kretanjeDostavljaca;
        public GeolocationRepository(IMongoDatabase mongoDatabase) : base(mongoDatabase, nameof(GeoCollection)) 
        {
            _mongoDatabase = mongoDatabase;
            _kretanjeDostavljaca = this._mongoDatabase.GetCollection<LocationDocument>(MongoCollections.KretanjeDostavljaca);
            CreateGeospatialIndex();
        }

        private void CreateGeospatialIndex()
        {
            var keys = Builders<LocationDocument>.IndexKeys.Geo2DSphere("location");
            var options = new CreateIndexOptions { Background = true }; // Background indexing to avoid blocking
            var model = new CreateIndexModel<LocationDocument>(keys, options);

            _kretanjeDostavljaca.Indexes.CreateOne(model);
        }

        public string GetGeolocation(double longitude, double latitude)
        {

            var point = GeoJson.Point(GeoJson.Geographic(longitude, latitude));

            var filter = Builders<LocationDocument>.Filter.Near("location", point);

            var documents = _kretanjeDostavljaca.Find(filter).ToList();


            return "address";

        }
    }
}
