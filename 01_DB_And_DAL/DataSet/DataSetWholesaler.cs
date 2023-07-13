using _01_DB.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _01_DB.DataSet
{
    public class DataSetWholesaler : IEntityTypeConfiguration<Wholesaler>
    {
        public void Configure(EntityTypeBuilder<Wholesaler> builder)
        {
            builder.HasData(
                new Wholesaler
                {
                    Id = 1,
                    Name = "GeneDrinks"
                },
                new Wholesaler
                {
                    Id = 2,
                    Name = "TangissartShop"
                }
            );

        }
    }
}
