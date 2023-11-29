using System.Linq.Expressions;

namespace PizzaMaster.Application.Repositories
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> Find(Expression<Func<T, bool>> expression, string[]? includes = null);
        T SingleOrDefault(Expression<Func<T, bool>> expression, string[]? includes = null);
        List<T> GetAll(string[]? includes = null);
        bool Any(Expression<Func<T, bool>> expression);

        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);

        T TryNewSingleOrDefault(Expression<Func<T, bool>> expression, IEnumerable<(Expression<Func<T, object>> NavigationProperty, string[] ChildProperties)>? includes = null);
        IQueryable<T> IncludeRelatedEntities(IQueryable<T> query, Expression<Func<T, object>> navigationProperty, params string[] childProperties);
    }
}
