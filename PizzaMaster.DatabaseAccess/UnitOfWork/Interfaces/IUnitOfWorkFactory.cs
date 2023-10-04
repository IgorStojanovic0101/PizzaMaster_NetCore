namespace WebAPI
{
    public interface IUnitOfWorkFactory
    {
        IUnitOfWork Create();
    }
}
