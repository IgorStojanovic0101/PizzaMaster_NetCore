using DataAccess;
using Microsoft.EntityFrameworkCore;
using PizzaMaster.DatabaseAccess.UnitOfWork;
using PizzaMaster.DatabaseAccess.UnitOfWork.IRepositories;

namespace WebAPI
{
    public class UnitOfWork :  IUnitOfWork
    {
        
        private readonly ApplicationDbContext _applicationDbContext;


        public IRestoraniRepository RestoraniRepository { get; private set; }
        public IErrorsRepository ErrorsRepository { get; private set; }


        public UnitOfWork(ApplicationDbContext databaseContext)
        {
            _applicationDbContext = databaseContext;

            RestoraniRepository = new RestoraniRepository(_applicationDbContext);
            ErrorsRepository = new ErrorsRepository(_applicationDbContext);
        }
        public void SaveChanges()
        {
             _applicationDbContext.SaveChanges();
        }


    }
}
