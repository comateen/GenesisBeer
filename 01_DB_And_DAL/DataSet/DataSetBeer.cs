using _01_DB.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    Degree = float.Parse("8.4"),
                    Price = float.Parse("2.7"),
                    BreweryId = 1
                },
                new Beer
                {
                    Id = 2,
                    Name = "Kwak",
                    Degree = float.Parse("8.4"),
                    Price = float.Parse("2.45"),
                    BreweryId = 1
                },
                new Beer
                {
                    Id = 3,
                    Name = "WestVletteren Blonde",
                    Degree = float.Parse("5.8"),
                    Price = float.Parse("8"),
                    BreweryId = 2
                },
                new Beer
                {
                    Id = 4,
                    Name = "WestVletteren 8",
                    Degree = float.Parse("8"),
                    Price = float.Parse("11"),
                    BreweryId = 2
                },
                new Beer
                {
                    Id = 5,
                    Name = "WestVletteren 12",
                    Degree = float.Parse("12"),
                    Price = float.Parse("14"),
                    BreweryId = 2
                },
                new Beer
                {
                    Id = 6,
                    Name = "Grimbergen Blonde",
                    Degree = float.Parse("6.7"),
                    Price = float.Parse("2.2"),
                    BreweryId = 3
                },
                new Beer
                {
                    Id = 7,
                    Name = "Grimbergen Double",
                    Degree = float.Parse("6.5"),
                    Price = float.Parse("2.2"),
                    BreweryId = 3
                },
                new Beer
                {
                    Id = 8,
                    Name = "Grimbergen Triple",
                    Degree = float.Parse("8"),
                    Price = float.Parse("2.3"),
                    BreweryId = 3
                }
            );
        }
    }
}
