using Microsoft.EntityFrameworkCore;
using PizzaMaster.Application.Repositories;
using PizzaMaster.Data.EF;
using System.Linq.Expressions;

namespace PizzaMaster.DatabaseAccess.UnitOfWork
{
    public abstract class Repository<T> : IRepository<T> where T: class
    {
        private readonly ApplicationDbContext _db;
        private DbSet<T> _dbSet;

        protected Repository(ApplicationDbContext db)
        {
            this._db = db;
            this._dbSet = _db.Set<T>();
        }
        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> expression)
        {
            return await _dbSet.Where(expression).ToListAsync();
        }

        public async Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> expression) => await _dbSet.SingleOrDefaultAsync(expression);

        public bool Any(Expression<Func<T, bool>> expression) =>  _dbSet.Any(expression);

        public void Add(T entity)
        {
            this._dbSet.AddAsync(entity);
        }

        public void Update(T entity)
        {
            this._dbSet.Update(entity);
        }

        public void Delete(T entity)
        {
            this._dbSet.Remove(entity);
        }
    }
}
