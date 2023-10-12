
using Microsoft.EntityFrameworkCore;
using PizzaMaster.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaMaster.Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
               new User()  { Id = -2, Name =  "Igor Stojanovic", Email = "2232sd", Username = "IGGY", Password = "123" }
               
               );
          
        }
    }
}