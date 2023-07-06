using _01_DB.Entities;
using _02_DAL.Interfaces;
using _03_Models.Models;
using _04_SRV.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_SRV.Services
{
    public class BeerService : IBeerService
    {
        private readonly IBeerRepository _beerRepo;
        public BeerService(IBeerRepository beerRepo)
        {
            _beerRepo = beerRepo;
        }
        public IEnumerable<BeerClient> GetAllBeerWithBrewerAndSalers()
        {
            List<Beer> beers = new List<Beer>();
            if(_beerRepo.TryToGetAllBeerData(out beers))
            {
                List<BeerClient> beerClients = ConvertBeerFromDB(beers);
                
                return beerClients;
            }
            throw new Exception("Nous n'avons pas trouvé de bière");
        }

        private List<BeerClient> ConvertBeerFromDB(List<Beer> beers)
        {
            List<BeerClient> beerClients = new List<BeerClient>();

            foreach (Beer beer in beers)
            {
                BeerClient beerClient = new BeerClient();
                beerClient.Id = beer.Id;
                beerClient.Name = beer.Name;
                beerClient.Degree = beer.Degree;
                beerClient.Price = beer.Price;

                BreweryClient brewery = new BreweryClient();
                brewery.Id = beer.Brewer.Id;
                brewery.Name = beer.Brewer.Name;

                beerClient.Brewery = brewery;

                List<WholesalerClient> wholesalers = new List<WholesalerClient>();
                
                foreach (StockBeerWholesaler wholesalerDB in beer.Wholesalers)
                {
                    WholesalerClient wholesaler = new WholesalerClient();
                    if(wholesalerDB.Saler != null)
                    {
                        wholesaler.Id = wholesalerDB.Saler.Id;
                        wholesaler.Name = wholesalerDB.Saler.Name;
                    }
                    
                    wholesalers.Add(wholesaler);
                }
                beerClient.Wholesalers = wholesalers;

                beerClients.Add(beerClient);
            }
            return beerClients;
        }
    }
}
