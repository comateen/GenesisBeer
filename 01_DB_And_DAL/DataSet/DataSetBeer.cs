using _01_DB.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _01_DB.DataSet
{
    public class DataSetBeer : IEntityTypeConfiguration<Beer>
    {
        public void Configure(EntityTypeBuilder<Beer> builder)
        {
            builder.HasData(
                new Beer
                {
                    Id = 1,
                    Name = "Triple Karmeliet",
                    Degree = 8.4,
                    Price = 2.7,
                    BreweryId = 1
                },
                new Beer
                {
                    Id = 2,
                    Name = "Kwak",
                    Degree = 8.4,
                    Price = 2.45,
                    BreweryId = 1
                },
                new Beer
                {
                    Id = 3,
                    Name = "WestVletteren Blonde",
                    Degree = 5.8,
                    Price = 8,
                    BreweryId = 2
                },
                new Beer
                {
                    Id = 4,
                    Name = "WestVletteren 8",
                    Degree = 8,
                    Price = 11,
                    BreweryId = 2
                },
                new Beer
                {
                    Id = 5,
                    Name = "WestVletteren 12",
                    Degree = 12,
                    Price = 14,
                    BreweryId = 2
                },
                new Beer
                {
                    Id = 6,
                    Name = "Grimbergen Blonde",
                    Degree = 6.7,
                    Price = 2.2,
                    BreweryId = 3
                },
                new Beer
                {
                    Id = 7,
                    Name = "Grimbergen Double",
                    Degree = 6.5,
                    Price = 2.2,
                    BreweryId = 3
                },
                new Beer
                {
                    Id = 8,
                    Name = "Grimbergen Triple",
                    Degree = 8,
                    Price = 2.3,
                    BreweryId = 3
                }
            );
        }
    }
}
