
using Microsoft.EntityFrameworkCore;
using PizzaMaster.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaMaster.DataAccess.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
               new User() { Id = 1, Name = "Igor", Email = "2232sd", Username = "igor", Password = "123" });

        }
    }
}