using _01_DB.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _01_DB.EntitiesConfigurations
{
    public class WholesalerConfiguration : IEntityTypeConfiguration<Wholesaler>
    {
        public void Configure(EntityTypeBuilder<Wholesaler> builder)
        {
            builder.ToTable("Wholesaler");

            builder.HasKey("Id");

            builder.Property(nameof(Wholesaler.Id))
                   .ValueGeneratedOnAdd();

            builder.Property(nameof(Wholesaler.Name))
                   .IsRequired()
                   .HasMaxLength(50);
        }
    }
}
