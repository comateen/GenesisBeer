using _01_DB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_UT
{
    public class FakeContext
    {
        public List<Beer> beers { get; set; }
        public List<Brewery> breweries { get; set; }
        public List<Wholesaler> wholesalers { get; set; }
        public List<StockBeerWholesaler> stockBeerWholesalers { get; set; }

        public static FakeContext SeedContext()
        {
            FakeContext dataContext = new FakeContext();
            dataContext.beers = new List<Beer>();
            dataContext.beers.AddRange(new List<Beer>() {
                new Beer { Id = 1, Name = "Triple Karmeliet", Degree = 8.4,Price = 2.7,BreweryId = 1 },
                new Beer { Id=2,Name="Kwak",Degree=8.4, Price=2.45, BreweryId=1 },
                new Beer { Id=3,Name="WestVletterenBlonde", Degree=5.8, Price=8, BreweryId=2 },
                new Beer { Id=4, Name="WestVletteren8", Degree=8, Price=11, BreweryId=2 },
                new Beer { Id=5, Name="WestVletteren12", Degree=12, Price=14, BreweryId=2 },
                new Beer { Id=6, Name="GrimbergenBlonde", Degree=6.7, Price=2.2, BreweryId=3 },
                new Beer { Id=7, Name="GrimbergenDouble", Degree=6.5, Price=2.2, BreweryId=3 },
                new Beer { Id=8, Name="GrimbergenTriple", Degree=8, Price=2.3, BreweryId=3 }
            });
            dataContext.breweries = new List<Brewery>();
            dataContext.breweries.AddRange(new List<Brewery>() {
                new Brewery { Id = 1, Name = "Bosteels" },
                new Brewery { Id = 2, Name = "Abbaye St-Sixtus" },
                new Brewery { Id = 3, Name = "Abbaye de Grimbergen" }
            });
            dataContext.wholesalers = new List<Wholesaler>();
            dataContext.wholesalers.AddRange(new List<Wholesaler>() {
                new Wholesaler { Id = 1, Name = "GeneDrinks" },
                new Wholesaler { Id = 2, Name = "TangissartShop" }
            });
            dataContext.stockBeerWholesalers = new List<StockBeerWholesaler>();
            dataContext.stockBeerWholesalers.AddRange(new List<StockBeerWholesaler>() {
                new StockBeerWholesaler { BeerId = 1, WholesalerId = 1, Quantity = 500 },
                new StockBeerWholesaler { BeerId = 2, WholesalerId = 1, Quantity = 300 },
                new StockBeerWholesaler { BeerId = 6, WholesalerId = 1, Quantity = 200 },
                new StockBeerWholesaler { BeerId = 7, WholesalerId = 1, Quantity = 200 },
                new StockBeerWholesaler { BeerId = 3, WholesalerId = 2, Quantity = 200 },
                new StockBeerWholesaler { BeerId = 4, WholesalerId = 2, Quantity = 200 },
                new StockBeerWholesaler { BeerId = 5, WholesalerId = 2, Quantity = 200 }
            });

            return dataContext;
        }
    }
}
