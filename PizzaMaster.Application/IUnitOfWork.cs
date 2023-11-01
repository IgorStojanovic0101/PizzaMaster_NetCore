

using PizzaMaster.Application.Repositories;

namespace PizzaMaster.Application
{
    public interface IUnitOfWork
    {
        IRestoranRepository RestoranRepository { get; }

        IErrorRepository ErrorRepository { get; }

        IUserRepository UserRepository { get; }

        IHomeDescRepository HomeDescRepository { get; }

        IImageRepository ImageRepository { get; }

        void SaveChanges();
    }
}
