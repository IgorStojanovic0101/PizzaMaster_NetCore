

using PizzaMaster.Domain;
using PizzaMaster.Domain.Entities;
using System.Linq.Expressions;

namespace PizzaMaster.Application.Repositories
{
    public interface IRestoranRepository : IRepository<Restoran>
    {
         List<Restoran> GetAll(IEnumerable<(Expression<Func<Restoran, object>> NavigationProperty, string[] ChildProperties)>? includes = null);
    }
}
