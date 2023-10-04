using DataAccess;

namespace WebAPI
{
    public class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public UnitOfWorkFactory(ApplicationDbContext applicationDbContext) { 
            _applicationDbContext = applicationDbContext; 
        }
        
        public IUnitOfWork Create() => new UnitOfWork(_applicationDbContext);
        
    }
}
