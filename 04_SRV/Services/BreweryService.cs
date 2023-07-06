
using _01_DB.Entities;
using _02_DAL.Interfaces;
using _03_Models.Models;
using _03_Models.VM;
using _04_SRV.Interfaces;

namespace _04_SRV.Services
{
    public class BreweryService : IBreweryService
    {
        private readonly IBreweryRepository _breweryRepository;

        public BreweryService(IBreweryRepository breweryRepository)
        {
            _breweryRepository = breweryRepository;
        }

        public IEnumerable<BreweryWithBeersAndSalers> GetAllBrewerWithBeerAndSalers()
        {
            List<Brewery> breweries = new List<Brewery>();
            if(_breweryRepository.TryToGetAllBreweryData(out breweries))
            {
                List<BreweryWithBeersAndSalers> breweryWBS = ConvertBreweriesFromDB(breweries);

                return breweryWBS;
            }
            throw new Exception("Nous n'avons pas trouvé de brasseur");
        }

        private List<BreweryWithBeersAndSalers> ConvertBreweriesFromDB(List<Brewery> breweries)
        {
            List<BreweryWithBeersAndSalers> breweryWBSList = new List<BreweryWithBeersAndSalers>();

            foreach(Brewery brewery in breweries)
            {
                BreweryWithBeersAndSalers breweryWBS = new BreweryWithBeersAndSalers();
                breweryWBS.Id = brewery.Id;
                breweryWBS.Name = brewery.Name;

                List<BeerClient> beerClients = new List<BeerClient>();
                foreach(Beer beer in brewery.Beers)
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

                    foreach (StockBeerWholesaler wholesalerDB in beer.Wholesalers)
                    {
                        WholesalerClient wholesaler = new WholesalerClient();
                        if (wholesalerDB.Saler != null)
                        {
                            wholesaler.Id = wholesalerDB.Saler.Id;
                            wholesaler.Name = wholesalerDB.Saler.Name;
                        }

                        wholesalers.Add(wholesaler);
                    }
                    beerClient.Wholesalers = wholesalers;
                    beerClients.Add(beerClient);
                }
                breweryWBS.Beers = beerClients;
                breweryWBSList.Add(breweryWBS);
            }
            return breweryWBSList;
        }
    }
}
