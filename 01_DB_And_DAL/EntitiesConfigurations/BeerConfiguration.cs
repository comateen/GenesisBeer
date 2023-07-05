using _01_DB.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _01_DB.EntitiesConfigurations
{
    public class BeerConfiguration : IEntityTypeConfiguration<Beer>
    {
        public void Configure(EntityTypeBuilder<Beer> builder)
        {
            builder.ToTable("Beer");

            builder.HasKey("Id");

            builder.Property(nameof(Beer.Id))
                   .ValueGeneratedOnAdd();

            builder.Property(nameof(Beer.Name))
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(nameof(Beer.Degree))
                   .IsRequired();

            builder.Property(nameof(Beer.Price))
                   .IsRequired();

            //one-to-many
            builder.HasOne<Brewery>(b => b.Brewer)
                   .WithMany(br => br.Beers)
                   .HasForeignKey(br => br.BreweryId);
        }
    }
}
