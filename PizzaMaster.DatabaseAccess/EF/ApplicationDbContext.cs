using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using PizzaMaster.DataAccess.Extensions;
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
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<UserRole> UserRoles { get; set; }

        public virtual DbSet<Language> Languages { get; set; } = null!;
        public virtual DbSet<Dictionary> Dictionaries { get; set; } = null!;
        public virtual DbSet<NameRelationDictionary> NameRelationDictionaries { get; set; } = null!;



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
          
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HomeDesc>(entity =>
            {
                entity.HasIndex(e => e.ImageId)
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
                entity.HasIndex(e => e.ImageId)
                    .IsUnique();

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Image)
                    .WithOne(p => p.PasteType)
                    .HasForeignKey<PasteType>(d => d.ImageId);
            });

            modelBuilder.Entity<PizzaType>(entity =>
            {
                entity.HasIndex(e => e.ImageId)
                    .IsUnique();

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
                entity.HasIndex(e => e.ImageId)
                    .IsUnique();

                entity.HasIndex(e => e.RestoranId);

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

            modelBuilder.Entity<Role>(entity =>

            entity.Property(e => e.RoleName).HasMaxLength(50));

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.HasKey(ur => ur.Id);

                entity.HasOne(ur => ur.User)
                .WithMany(u => u.UserRoles)
                .HasForeignKey(ur => ur.UserId);

                entity.HasOne(ur => ur.Role)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.RoleId);
            });

            modelBuilder.Entity<Dropdown>(entity =>
            {
                entity.Property(e => e.DropdownName).HasMaxLength(50);
            });

            modelBuilder.Entity<DropdownRelationItem>(entity =>
            {
                entity.HasKey(ur => ur.Id);

                entity.HasOne(ur => ur.Dropdown)
                .WithMany(u => u.DropdownRelationItems)
                .HasForeignKey(ur => ur.DropdownId);

                entity.HasOne(ur => ur.DropItem)
                    .WithMany(r => r.DropdownRelationItems)
                    .HasForeignKey(ur => ur.DropItemId);
            });

            modelBuilder.Entity<DropItem>(entity =>
            {
                entity.Property(e => e.DropItemName).HasMaxLength(50);
            });

            modelBuilder.Entity<Language>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(250);

            });

            modelBuilder.Entity<Dictionary>(entity =>
            {
                entity.Property(e => e.Value).HasMaxLength(250);
                entity.Property(e => e.Name).HasMaxLength(250);

                entity.HasOne(d => d.Language)
                   .WithOne(p => p.Dictionary)
                   .HasForeignKey<Dictionary>(d => d.LanguageId);
            });


            modelBuilder.Entity<NameRelationDictionary>(entity =>
            {
                entity.HasOne(d => d.Language)
                  .WithOne(p => p.NameRelationDictionary)
                  .HasForeignKey<NameRelationDictionary>(d => d.LanguageId);
            });

            modelBuilder.Seed();

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
