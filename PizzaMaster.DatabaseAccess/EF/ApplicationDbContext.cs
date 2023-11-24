using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using PizzaMaster.Domain.Entities;

namespace PizzaMaster.DataAccess.EF
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
        public virtual DbSet<HomeDesc> HomeDescs { get; set; } = null!;
        public virtual DbSet<Image> Images { get; set; } = null!;
        public virtual DbSet<PasteType> PasteTypes { get; set; } = null!;
        public virtual DbSet<PizzaType> PizzaTypes { get; set; } = null!;
        public virtual DbSet<Restoran> Restorans { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UserLog> UserLogs { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=ConnectionStrings:DefaultConnection", x => x.UseNetTopologySuite());
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HomeDesc>(entity =>
            {
                entity.HasIndex(e => e.ImageId, "IX_HomeDescs_ImageId")
                    .IsUnique();

                entity.Property(e => e.Text).HasMaxLength(250);

                entity.HasOne(d => d.Image)
                    .WithOne(p => p.HomeDesc)
                    .HasForeignKey<HomeDesc>(d => d.ImageId);
            });

            modelBuilder.Entity<Image>(entity =>
            {
                entity.Property(e => e.Url).HasMaxLength(250);
            });

            modelBuilder.Entity<PasteType>(entity =>
            {
                entity.HasIndex(e => e.ImageId, "IX_PasteTypes_ImageId")
                    .IsUnique()
                    .HasFilter("([ImageId] IS NOT NULL)");

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Image)
                    .WithOne(p => p.PasteType)
                    .HasForeignKey<PasteType>(d => d.ImageId);
            });

            modelBuilder.Entity<PizzaType>(entity =>
            {
                entity.HasIndex(e => e.ImageId, "IX_PizzaTypes_ImageId")
                    .IsUnique()
                    .HasFilter("([ImageId] IS NOT NULL)");

                entity.Property(e => e.Description).HasMaxLength(255);

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.Image)
                    .WithOne(p => p.PizzaType)
                    .HasForeignKey<PizzaType>(d => d.ImageId);
            });

            modelBuilder.Entity<Restoran>(entity =>
            {
                entity.Property(e => e.RestoranIme).HasMaxLength(200);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.ImageId, "IX_Users_ImageId")
                    .IsUnique()
                    .HasFilter("([ImageId] IS NOT NULL)");

                entity.HasIndex(e => e.RestoranId, "IX_Users_RestoranId");

                entity.Property(e => e.Username).HasMaxLength(50);

                entity.HasOne(d => d.Image)
                    .WithOne(p => p.User)
                    .HasForeignKey<User>(d => d.ImageId);

                entity.HasOne(d => d.Restoran)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RestoranId);
            });

            modelBuilder.Entity<UserLog>(entity =>
            {
                entity.Property(e => e.Email).HasMaxLength(250);

                entity.Property(e => e.Username).HasMaxLength(250);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
