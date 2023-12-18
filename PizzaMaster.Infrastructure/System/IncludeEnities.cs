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
    public static class IncludeEnities
    {

        // public static string[] All => PropertyHelper.GetVirtualPublicPropertyNames<T>();

        public static class HomeDescription
        {
            public static List<(Expression<Func<PizzaMaster.Domain.Entities.HomeDesc, object>> NavigationProperty, string[] ChildProperties)> Entities
            {
                get
                {
                    Expression<Func<PizzaMaster.Domain.Entities.HomeDesc, object>> navigationProperty = x => x.Image;

                    string[] childProperties = { };


                    return new List<(Expression<Func<PizzaMaster.Domain.Entities.HomeDesc, object>> NavigationProperty, string[] ChildProperties)>
                    {
                        (navigationProperty, childProperties)
                     };
                }
            }

        }

        public static class PizzaType
        {
            public static List<(Expression<Func<PizzaMaster.Domain.Entities.PizzaType, object>> NavigationProperty, string[] ChildProperties)> Entities
            {
                get
                {
                    Expression<Func<PizzaMaster.Domain.Entities.PizzaType, object>> navigationProperty = x => x.Image;

                    string[] childProperties = { };


                    return new List<(Expression<Func<PizzaMaster.Domain.Entities.PizzaType, object>> NavigationProperty, string[] ChildProperties)>
                    {
                        (navigationProperty, childProperties)
                     };
                }
            }

        }

        public static class PasteType
        {
            public static List<(Expression<Func<PizzaMaster.Domain.Entities.PasteType, object>> NavigationProperty, string[] ChildProperties)> Entities
            {
                get
                {
                    Expression<Func<PizzaMaster.Domain.Entities.PasteType, object>> navigationProperty = x => x.Image;

                    string[] childProperties = { };


                    return new List<(Expression<Func<PizzaMaster.Domain.Entities.PasteType, object>> NavigationProperty, string[] ChildProperties)>
                    {
                        (navigationProperty, childProperties)
                     };
                }
            }

        }

        
        public static class User
        {
            public static List<(Expression<Func<PizzaMaster.Domain.Entities.User, object>> NavigationProperty, string[] ChildProperties)> Entities
            {
                get
                {
                    Expression<Func<PizzaMaster.Domain.Entities.User, object>> UserRoles = x => x.UserRoles;
                    Expression<Func<PizzaMaster.Domain.Entities.User, object>> Images = x => x.Image;


                    var child = ExpressionHelper.GetMemberName((UserRole x) => x.Role);
                    
                    string[] childProperties = { child };
                    string[] childProperties2 = { };


                    return new List<(Expression<Func<PizzaMaster.Domain.Entities.User, object>> NavigationProperty, string[] ChildProperties)>
                    {
                        (UserRoles, childProperties),
                        (Images, childProperties2)

                     };
                }
            }
        }

        

        public static class Dropdown
        {
            public static List<(Expression<Func<PizzaMaster.Domain.Entities.Dropdown, object>> NavigationProperty, string[] ChildProperties)> Entities
            {
                get
                {
                    Expression<Func<PizzaMaster.Domain.Entities.Dropdown, object>> navigationProperty = x => x.DropdownRelationItems;

                    //var child = ExpressionHelper.GetMemberName((PizzaMaster.Domain.Entities.Dropdown x) => x.DropdownRelationItems.Select(x => x.DropItem));
                    var child = ExpressionHelper.GetMemberName((DropdownRelationItem x) => x.DropItem);
                    string[] childProperties = { child };


                    return new List<(Expression<Func<PizzaMaster.Domain.Entities.Dropdown, object>> NavigationProperty, string[] ChildProperties)>
                    {
                        (navigationProperty, childProperties)
                     };
                }
            }
        }


    }

    public static class ExpressionHelper
    {
        public static string GetMemberName<T, TProperty>(Expression<Func<T, TProperty>> expression)
        {
            if (expression.Body is MemberExpression memberExpression)
            {
                return memberExpression.Member.Name;
            }

            throw new ArgumentException("Expression is not a member access", nameof(expression));
        }

        
    }

    //public static class PropertyHelper
    //{
    //    public static string[] GetVirtualPublicPropertyNames<T>()
    //    {
    //        return typeof(T)
    //            .GetProperties(BindingFlags.Public | BindingFlags.Instance)
    //            .Where(property => property.GetGetMethod().IsVirtual)
    //            .Select(property => property.Name)
    //            .ToArray();
    //    }
    //}



}
