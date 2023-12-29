using MongoDB.Driver;
using PizzaMaster.Application;
using PizzaMaster.Application.Repositories;
using PizzaMaster.DataAccess.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaMaster.DataAccess.Mongo
{
    public class MongoUnitOfWork : IMongoUnitOfWork
    {
        private readonly IMongoDatabase _mongoDatabase;

        public MongoUnitOfWork(IMongoDatabase mongoDatabase) { 
            _mongoDatabase = mongoDatabase;
            GeolocationRepository = new GeolocationRepository(_mongoDatabase);

        }

        public IGeolocationRepository GeolocationRepository { get; private set; }

    }
}
