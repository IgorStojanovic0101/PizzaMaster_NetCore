namespace PizzaMaster.Application
{
    public interface IUnitOfWorkFactory
    {
        IUnitOfWork Create();

        IMongoUnitOfWork CreateMongo();
    }
}
