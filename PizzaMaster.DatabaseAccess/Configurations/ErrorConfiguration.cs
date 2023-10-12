using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PizzaMaster.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaMaster.Data.Configurations
{
    public class ErrorConfiguration : IEntityTypeConfiguration<ErrorEntity>
    {
        public void Configure(EntityTypeBuilder<ErrorEntity> builder)
        {
            builder.ToTable("Errors");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Naziv).IsRequired();

           


        }
    }
}
