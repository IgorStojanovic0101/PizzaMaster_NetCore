using PizzaMaster.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaMaster.Infrastructure.System
{
    public static class IncludeEnities
    {
        public static class Restoran
        {
            public static string[] All => new string[] { "Users" };
        }

        public static class User
        {
            public static string[] All => new string[] { "Restoran" };

        }

        public static class HomeDescription
        {
            public static string[] All => new string[] { "Image" };

        }
    }

   
}
