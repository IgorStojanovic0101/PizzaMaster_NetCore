namespace PizzaMaster.Application
{
    public interface IUnitOfWorkFactory
    {
        IUnitOfWork Create();
    }
}
