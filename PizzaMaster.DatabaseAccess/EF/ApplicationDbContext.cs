using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using PizzaMaster.Domain.Entities;

namespace PizzaMaster.Data.EF
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public virtual DbSet<Error> Errors { get; set; } = null!;
        public virtual DbSet<PasteType> PasteTypes { get; set; } = null!;
        public virtual DbSet<PizzaType> PizzaTypes { get; set; } = null!;
        public virtual DbSet<Restoran> Restorans { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
       
        public virtual DbSet<Image> Images { get; set; } = null!;
        public virtual DbSet<HomeDesc> HomeDescs { get; set; } = null!;


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=ConnectionStrings:DefaultConnection", x => x.UseNetTopologySuite());
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PasteType>(entity =>
            {
                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<PizzaType>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(255);

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            });

            modelBuilder.Entity<Restoran>(entity =>
            {
                entity.Property(e => e.RestoranIme).HasMaxLength(200);
                entity.Property(e => e.DateFrom).IsRequired();
            });    

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.RestoranId, "IX_Users_RestoranId");                
                //entity.HasIndex(h => h.ImageId, "IX_Users_ImageId");  // Index on ImageId


                entity.Property(e => e.Username).HasMaxLength(50);

                entity.HasOne(d => d.Restoran)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RestoranId);

                entity.HasOne(hd => hd.Image)
                   .WithOne(i => i.User)
                   .HasForeignKey<User>(hd => hd.ImageId);

            });

            modelBuilder.Entity<HomeDesc>(entity =>
            {
                entity.HasOne(hd => hd.Image)         
                .WithOne(i => i.HomeDesc)       
                .HasForeignKey<HomeDesc>(hd => hd.ImageId); 

                entity.Property(hd => hd.Text)
                .HasMaxLength(250);
            });
           

                

            modelBuilder.Entity<Image>()
                .Property(i => i.Url)
                .IsRequired()
                .HasMaxLength(250);





            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
