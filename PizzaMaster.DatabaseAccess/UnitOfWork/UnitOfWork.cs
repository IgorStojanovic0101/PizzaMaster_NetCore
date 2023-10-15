using Microsoft.EntityFrameworkCore;
using PizzaMaster.Application;
using PizzaMaster.Application.Repositories;
using PizzaMaster.Data.EF;
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



        public UnitOfWork(ApplicationDbContext databaseContext)
        {
            _applicationDbContext = databaseContext;

            RestoranRepository = new RestoranRepository(_applicationDbContext);
            ErrorRepository = new ErrorRepository(_applicationDbContext);
            UserRepository = new UserRepository(_applicationDbContext);
        }
        public void SaveChanges()
        {
             _applicationDbContext.SaveChanges();
        }


    }
}
