
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PizzaMaster.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaMaster.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(x =>  x.Id);


            builder.Property(x => x.Id).UseIdentityColumn();


            builder.Property(x => x.Username).HasMaxLength(50);


            builder.HasOne(x => x.Restoran).WithMany(r => r.Users).HasForeignKey(x => x.RestoranId).IsRequired();

        }
    }
}
