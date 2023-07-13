using _01_DB.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _01_DB.EntitiesConfigurations
{
    public class StockBeerWholesalerConfiguration : IEntityTypeConfiguration<StockBeerWholesaler>
    {
        public void Configure(EntityTypeBuilder<StockBeerWholesaler> builder)
        {
            builder.ToTable("StockBeerWholesaler");
            //Définition d'un id composite
            builder.HasKey(sbw => new { sbw.BeerId, sbw.WholesalerId });

            //j'établie la  relation des fk vers leur table correspondante
            builder.HasOne(sbw => sbw.beer)
                   .WithMany(b => b.Wholesalers)
                   .HasForeignKey(b => b.BeerId);

            builder.HasOne(sbw => sbw.Saler)
                   .WithMany(w => w.Beers)
                   .HasForeignKey(w => w.WholesalerId);

            builder.Property(nameof(StockBeerWholesaler.Quantity))
                   .IsRequired();

        }
    }
}
