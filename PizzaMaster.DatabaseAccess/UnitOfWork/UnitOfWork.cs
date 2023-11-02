using Microsoft.EntityFrameworkCore;
using PizzaMaster.Application;
using PizzaMaster.Application.Repositories;
using PizzaMaster.Data.EF;
using PizzaMaster.Data.UnitOfWork;
using PizzaMaster.DatabaseAccess.UnitOfWork;
using PizzaMaster.Domain.Entities;

namespace PizzaMaster.DatabaseAccess.UnitOfWork
{
    public class UnitOfWork :  IUnitOfWork
    {
        
        private readonly ApplicationDbContext _applicationDbContext;


        public IRestoranRepository RestoranRepository { get; private set; }
        public IErrorRepository ErrorRepository { get; private set; }

        public IUserRepository UserRepository { get; private set; }

        public IHomeDescRepository HomeDescRepository { get; private set; }

        public IImageRepository ImageRepository { get; private set; }

        public IPizzaTypeRepository PizzaTypeRepository { get; private set; }

        public IPastaTypeRepository PastaTypeRepository { get; private set; }

        public UnitOfWork(ApplicationDbContext databaseContext)
        {
            _applicationDbContext = databaseContext;

            RestoranRepository = new RestoranRepository(_applicationDbContext);
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
