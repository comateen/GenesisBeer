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
    public class DataSetStockBeerWholeSaler : IEntityTypeConfiguration<StockBeerWholesaler>
    {
        public void Configure(EntityTypeBuilder<StockBeerWholesaler> builder)
        {
            builder.HasData(
                new StockBeerWholesaler { BeerId = 1, WholesalerId = 1, Quantity = 500 },
                new StockBeerWholesaler { BeerId = 2, WholesalerId = 1, Quantity = 300 },
                new StockBeerWholesaler { BeerId = 6, WholesalerId = 1, Quantity = 200 },
                new StockBeerWholesaler { BeerId = 7, WholesalerId = 1, Quantity = 200 },
                new StockBeerWholesaler { BeerId = 3, WholesalerId = 2, Quantity = 200 },
                new StockBeerWholesaler { BeerId = 4, WholesalerId = 2, Quantity = 200 },
                new StockBeerWholesaler { BeerId = 5, WholesalerId = 2, Quantity = 200 }
            );
        }
    }
}
