using Microsoft.EntityFrameworkCore;
using PizzaMaster.Application;
using PizzaMaster.Application.Repositories;
using PizzaMaster.DataAccess.UnitOfWork;
using PizzaMaster.DataAccess.EF;
using PizzaMaster.Domain.Entities;
using System.Data;

namespace PizzaMaster.DataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly ApplicationDbContext _applicationDbContext;

        public IRestoranRepository RestoranRepository { get; private set; }
        public IErrorRepository ErrorRepository { get; private set; }

        public IUserRepository UserRepository { get; private set; }

        public IHomeDescRepository HomeDescRepository { get; private set; }

        public IImageRepository ImageRepository { get; private set; }

        public IPizzaTypeRepository PizzaTypeRepository { get; private set; }

        public IPastaTypeRepository PastaTypeRepository { get; private set; }

        public UnitOfWork(ApplicationDbContext databaseContext, IDbConnection dbConnection)
        {
            _applicationDbContext = databaseContext;

            RestoranRepository = new RestoranRepository(_applicationDbContext, dbConnection);
            ErrorRepository = new ErrorRepository(_applicationDbContext);
            UserRepository = new UserRepository(_applicationDbContext);
            HomeDescRepository = new HomeDescRepository(_applicationDbContext);
            ImageRepository = new ImageRepository(_applicationDbContext);
            PizzaTypeRepository = new PizzaTypeRepository(_applicationDbContext);
            PastaTypeRepository = new PastaTypeRepository(_applicationDbContext);

        }
        public void SaveChanges()
        {
            _applicationDbContext.SaveChanges();
        }


    }
}
