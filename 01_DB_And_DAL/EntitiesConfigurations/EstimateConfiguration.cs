using _01_DB.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_DB.EntitiesConfigurations
{
    public class EstimateConfiguration : IEntityTypeConfiguration<Estimate>
    {
        public void Configure(EntityTypeBuilder<Estimate> builder)
        {
            builder.ToTable("Estimate");
            
            builder.HasKey("Id");

            builder.Property(nameof(Estimate.Id))
                   .ValueGeneratedOnAdd();

            builder.Property(nameof(Estimate.WholesalerId))
                   .IsRequired();
        }
    }
}
