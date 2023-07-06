using _01_DB.Entities;
using _03_Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_SRV.Helper
{
    public class ServiceHelper
    {
        protected List<BeerClient> SetBeerClient(List<Beer> beers)
        {
            List<BeerClient> beerClients = new List<BeerClient>();
            foreach (Beer beer in beers)
            {
                BeerClient beerClient = new BeerClient();
                beerClient.Id = beer.Id;
                beerClient.Name = beer.Name;
                beerClient.Degree = beer.Degree;
                beerClient.Price = beer.Price;

                BreweryClient brewer = new BreweryClient();
                brewer.Id = beer.Brewer.Id;
                brewer.Name = beer.Brewer.Name;

                List<WholesalerClient> wholesalers = new List<WholesalerClient>();

                beerClient.Wholesalers = SetWholesalers(beer.Wholesalers);

                beerClients.Add(beerClient);
            }
            return beerClients;
        }

        protected List<WholesalerClient> SetWholesalers(List<StockBeerWholesaler> wholesalers)
        {
            List<WholesalerClient> wholesalersClient = new List<WholesalerClient>();
            foreach (StockBeerWholesaler wholesalerDB in wholesalers)
            {
                WholesalerClient wholesaler = new WholesalerClient();
                if (wholesalerDB.Saler != null)
                {
                    wholesaler.Id = wholesalerDB.Saler.Id;
                    wholesaler.Name = wholesalerDB.Saler.Name;
                }

                wholesalersClient.Add(wholesaler);
            }
            return wholesalersClient;
        }
    }
}
