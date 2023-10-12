using System.Linq.Expressions;

namespace PizzaMaster.Application.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> expression);
        Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> expression);
        bool Any(Expression<Func<T, bool>> expression);

        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
