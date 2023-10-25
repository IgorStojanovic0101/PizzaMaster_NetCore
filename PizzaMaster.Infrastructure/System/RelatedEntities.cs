using PizzaMaster.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaMaster.Infrastructure.System
{
    public static class RelatedEntities
    {
        public static string[] Restoran => new string[] { "Users" };

        public static string[] User => new string[] { "Restoran" };

    }

    //IncludeProperties.Restoran

    // Returs array with Users, Etc..
}
