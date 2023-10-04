using PizzaMaster.DatabaseAccess.UnitOfWork.IRepositories;

namespace WebAPI
{
    public interface IUnitOfWork
    {
        IRestoraniRepository RestoraniRepository { get; }

        IErrorsRepository ErrorsRepository { get; }

        void SaveChanges();
    }
}
