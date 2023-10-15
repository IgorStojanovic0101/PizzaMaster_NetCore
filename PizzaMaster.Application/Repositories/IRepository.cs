using System.Linq.Expressions;

namespace PizzaMaster.Application.Repositories
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> Find(Expression<Func<T, bool>> expression);
        T SingleOrDefault(Expression<Func<T, bool>> expression);
        List<T> GetAll();
        bool Any(Expression<Func<T, bool>> expression);

        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
