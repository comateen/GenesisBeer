using _01_DB.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _01_DB.DataSet
{
    public class DataSetBrewery : IEntityTypeConfiguration<Brewery>
    {
        public void Configure(EntityTypeBuilder<Brewery> builder)
        {
            builder.HasData(
                new Brewery
                {
                    Id = 1,
                    Name = "Bosteels"
                },
                new Brewery
                {
                    Id = 2,
                    Name = "Abbaye St-Sixtus"
                },
                new Brewery
                {
                    Id = 3,
                    Name = "Abbaye de Grimbergen"
                }

            );
        }
    }
}
