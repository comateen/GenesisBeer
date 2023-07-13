using _01_DB.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _01_DB.EntitiesConfigurations
{
    public class BeerEstimateConfiguration : IEntityTypeConfiguration<BeerEstimate>
    {
        public void Configure(EntityTypeBuilder<BeerEstimate> builder)
        {
            builder.ToTable("BeerEstimate");

            builder.HasKey(be => new { be.BeerId, be.EstimateId });

            builder.Property(nameof(BeerEstimate.Quantity))
                   .IsRequired();

            builder.HasOne<Estimate>(be => be.estimate)
                   .WithMany(e => e.Beers)
                   .HasForeignKey(e => e.EstimateId);
        }
    }
}
