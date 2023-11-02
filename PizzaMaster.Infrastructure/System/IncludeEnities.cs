using PizzaMaster.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PizzaMaster.Infrastructure.System
{
    public static class IncludeEnities
    {
        public static class Restoran
        {
            public static string[] All => PropertyHelper.GetVirtualPublicPropertyNames<Domain.Entities.Restoran>();
        }

        public static class User
        {
            public static string[] All => PropertyHelper.GetVirtualPublicPropertyNames<Domain.Entities.User>();

        }

        public static class HomeDescription
        {
            public static string[] All => PropertyHelper.GetVirtualPublicPropertyNames<Domain.Entities.HomeDesc>();

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
