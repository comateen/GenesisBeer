using _01_DB.Entities;
using _02_DAL.Interfaces;
using _03_Models.AddModels;
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
        private readonly IBreweryService _breweryService;

        public BeerService(IBeerRepository beerRepo, IBreweryService breweryService)
        {
            _beerRepo = beerRepo;
            _breweryService = breweryService;
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

        public void AddBeer(AddBeerModel addBeer)
        {
            //la validiter du addbeer model ne se fait (selon oi pas ici mais plutot dans une mvc et un modelstate.isvalid, dans le doute je vérifie juste si le brasseur est connu
            if (!_breweryService.IsBreweryExist(addBeer.BreweryId))
            {
                throw new Exception("le brasseur indiqué n'existe pas");
            }
            Beer beer = ConvertToBeerDB(addBeer);
            if (!_beerRepo.AddBeer(beer))
            {
                throw new Exception("Erreur lors de la sauvegarde de la bière");
            }
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

        private Beer ConvertToBeerDB(AddBeerModel addBeer)
        {
            Beer beer = new Beer();
            beer.Name = addBeer.Name;
            beer.Degree = addBeer.Degree;
            beer.BreweryId = addBeer.BreweryId;
            beer.Price = addBeer.Price;

            return beer;
        }

    }
}
