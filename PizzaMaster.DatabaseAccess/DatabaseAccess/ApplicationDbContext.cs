using Microsoft.EntityFrameworkCore;
using Models.Models;
using PizzaMaster.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<RestoranModel> Restorans { get; set; }
        public DbSet<ErrorModel> Errors { get; set; }



    }
}
