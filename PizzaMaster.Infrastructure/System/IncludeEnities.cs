using PizzaMaster.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PizzaMaster.Infrastructure.System
{
    public static class IncludeEnities<T> where T : class
    {

        public static string[] All => PropertyHelper.GetVirtualPublicPropertyNames<T>();

        public static class User 
        {
            public static List<(Expression<Func<PizzaMaster.Domain.Entities.User, object>> NavigationProperty, string[] ChildProperties)> userEntities 
                = new List<(Expression<Func<PizzaMaster.Domain.Entities.User, object>> NavigationProperty, string[] ChildProperties)>
             {
                (x => x.UserRoles, new [] { "Role" }),
             };
        }
       
    }
    public static class PropertyHelper
    {
        public static string[] GetVirtualPublicPropertyNames<T>()
        {
            return typeof(T)
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(property => property.GetGetMethod().IsVirtual)
                .Select(property => property.Name)
                .ToArray();
        }
    }



}
