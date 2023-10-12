using Microsoft.EntityFrameworkCore;
using PizzaMaster.Data.Configurations;
using PizzaMaster.Data.Extensions;
using PizzaMaster.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaMaster.Data.EF
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Configure using Fluent API
            //modelBuilder.ApplyConfiguration(new UserConfiguration());

            modelBuilder.ApplyConfiguration(new ErrorConfiguration());
            modelBuilder.ApplyConfiguration(new RestoranConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());

            //modelBuilder.Entity<User>()
            //    .HasOne(c => c.Restoran)
            //    .WithMany(u => u.Users)
            //    .HasForeignKey(c => c.RestoranId)
            //    .IsRequired();

            //Data seeding
            //modelBuilder.Seed();
            //base.OnModelCreating(modelBuilder);
        }
        public DbSet<Restoran> Restorans { get; set; }
        public DbSet<ErrorEntity> Errors { get; set; }
        public DbSet<User> Users { get; set; }



    }
}
