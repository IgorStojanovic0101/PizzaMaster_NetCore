using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PizzaMaster.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaMaster.Data.Configurations
{
    public class RestoranConfiguration : IEntityTypeConfiguration<Restoran>
    {
        public void Configure(EntityTypeBuilder<Restoran> builder)
        {
            builder.ToTable("Restorans");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.RestoranIme).HasMaxLength(200).IsRequired();

           

        }
    }
}
