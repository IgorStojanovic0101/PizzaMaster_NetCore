using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using PizzaMaster.Application.Repositories;
using PizzaMaster.DataAccess.EF;
using PizzaMaster.Domain.Entities;
using System.Linq.Expressions;
using System.Reflection;

namespace PizzaMaster.DataAccess.UnitOfWork
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        private DbSet<T> _dbSet;

        private ParameterExpression parameter;

        private BinaryExpression? dateTimeExpression;

        private bool ignoreDateTimeExpression = true;
        protected Repository(ApplicationDbContext db)
        {
            _dbSet = db.Set<T>();
            parameter = Expression.Parameter(typeof(T), "x");
            dateTimeExpression = GetDateToFilterExpression(parameter);
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> expression, string[]? includes = null)
        {
            var updatedExpression = UpdatedExpressions(expression, ignoreDateTimeExpression);
            var query = _dbSet.Where(updatedExpression).AsQueryable();

            query = includes?.Aggregate(query, (current, include) => current.Include(include)) ?? query;


            return query.ToList();
        }

        public virtual T SingleOrDefault(Expression<Func<T, bool>> expression, string[]? includes = null)
        {
            var updatedExpression = UpdatedExpressions(expression, ignoreDateTimeExpression);
            var query = _dbSet.Where(updatedExpression).AsQueryable();

            query = includes?.Aggregate(query, (current, include) => current.Include(include)) ?? query;


            return query.SingleOrDefault();
        }

        public virtual T TryNewSingleOrDefault(Expression<Func<T, bool>> expression, IEnumerable<(Expression<Func<T, object>> NavigationProperty, string[] ChildProperties)>? includes = null)
        {
            var updatedExpression = UpdatedExpressions(expression, ignoreDateTimeExpression);
            var query = _dbSet.Where(updatedExpression).AsQueryable();


            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include.NavigationProperty);

                    foreach (var childProperty in include.ChildProperties)
                    {
                        var memberExpression = (MemberExpression)include.NavigationProperty.Body;
                        var navigationPropertyName = memberExpression.Member.Name;

                        query = query.Include($"{navigationPropertyName}.{childProperty}");
                    }
                }
            }

            //query = query.Include(navigationProperty);

            //var memberExpression = (MemberExpression)navigationProperty.Body;
            //var navigationPropertyName = memberExpression.Member.Name;

            //foreach (var childProperty in childProperties)
            //{
            //    query = query.Include($"{navigationPropertyName}.{childProperty}");
            //}

            return query.SingleOrDefault();
        }


        public IQueryable<T> IncludeRelatedEntities(IQueryable<T> query, Expression<Func<T, object>> navigationProperty, params string[] childProperties)
        {
            query = _dbSet.AsQueryable();
            query = query.Include(navigationProperty);

            foreach (var childProperty in childProperties)
            {
                query = query.Include($"{navigationProperty.Name}.{childProperty}");
            }

            return query;
        }

        public bool Any(Expression<Func<T, bool>> expression) => _dbSet.Any(expression);

        public virtual void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        //custom expression moze biti null, ako zelim da mi GetAll vrati sve..
        public virtual List<T> GetAll(string[]? includes = null)
        {

            var updatedExpression = UpdatedExpressions(null, ignoreDateTimeExpression);

            var query = updatedExpression != null ? _dbSet.Where(updatedExpression).AsQueryable() : _dbSet.AsQueryable();

            query = includes?.Aggregate(query, (current, include) => current.Include(include)) ?? query;

            return query.ToList();
        }




        /// <summary>
        /// 
        /// </summary>
        /// <param name="customExpression"></param>
        /// <returns></returns>

        private Expression<Func<T, bool>>? UpdatedExpressions(Expression<Func<T, bool>>? customExpression, bool ignoreDateTimeExpression)
        {
            if (!ignoreDateTimeExpression && dateTimeExpression != null)
            {
                if (customExpression != null)
                {
                    var combinedCondition = Expression.AndAlso(dateTimeExpression, Expression.Invoke(customExpression, parameter)); //Combine both expression
                    return Expression.Lambda<Func<T, bool>>(combinedCondition, parameter);
                }
                else
                {
                    return Expression.Lambda<Func<T, bool>>(dateTimeExpression, parameter); //Only dateTime expression will be executed..
                }
            }
            else
            {
                return customExpression;
            }
        }


        private BinaryExpression? GetDateToFilterExpression(ParameterExpression parameter)
        {
            string _defaultPropertyDateTo = "DateTo";
            DateTime? myDateTime = DateTime.Now;

            PropertyInfo propertyInfo = typeof(T).GetProperty(_defaultPropertyDateTo);

            if (propertyInfo != null)
            {
                var property = Expression.Property(parameter, propertyInfo);
                var constant = Expression.Constant(myDateTime, typeof(DateTime?));
                var comparison = Expression.GreaterThan(property, constant);
                var isNull = Expression.Equal(property, Expression.Constant(null, typeof(DateTime?)));
                var combinedCondition = Expression.OrElse(comparison, isNull);
                return combinedCondition;
            }

            return null;
        }

    }
}
