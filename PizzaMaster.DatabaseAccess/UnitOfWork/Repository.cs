using Microsoft.EntityFrameworkCore;
using PizzaMaster.Application.Repositories;
using PizzaMaster.Data.EF;
using PizzaMaster.Domain.Entities;
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
        public  IEnumerable<T> Find(Expression<Func<T, bool>> expression) => _dbSet.Where(expression).ToList();
        

        public  T SingleOrDefault(Expression<Func<T, bool>> expression) =>  _dbSet.SingleOrDefault(expression);

        public List<T> GetAll() => _dbSet.ToList();

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
