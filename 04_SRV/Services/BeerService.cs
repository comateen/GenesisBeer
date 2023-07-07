using _01_DB.Entities;
using _02_DAL.Interfaces;
using _03_Models.AddModels;
using _03_Models.Models;
using _03_Models.VM;
using _04_SRV.Helper;
using _04_SRV.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_SRV.Services
{
    public class BeerService : ServiceHelper, IBeerService
    {
        #region private variable
        private readonly IBeerRepository _beerRepo;
        private readonly IBreweryService _breweryService;
        #endregion

        public BeerService(IBeerRepository beerRepo, IBreweryService breweryService)
        {
            _beerRepo = beerRepo;
            _breweryService = breweryService;
        }

        #region public method
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

        public BeerToShow GetOneBeerForEstimateReturn(int id)
        {
            Beer beerDB = new Beer();
            if(_beerRepo.GetOneBeer(id, out beerDB))
            {
                BeerToShow beerToShow = new BeerToShow();
                beerToShow.Id = beerDB.Id;
                beerToShow.Name = beerDB.Name;
                beerToShow.Degree = beerDB.Degree;
                beerToShow.Price = beerDB.Price;

                return beerToShow;
            }
            throw new Exception($"Problème lors de la récupération de la bière portant l'identifiant {id}");
        }

        public void AddBeer(AddBeerModel addBeer)
        {
            //la validiter du addbeer model ne se fait (selon moi pas ici mais plutot dans une mvc et un modelstate.isvalid, dans le doute je vérifie juste si le brasseur est connu
            if (!_breweryService.IsBreweryExist(addBeer.BreweryId))
            {
                throw new Exception("le brasseur indiqué n'existe pas");
            }
            //TODO voir comment vérifier que la bière n'existe pas 
            Beer beer = ConvertToBeerDB(addBeer);
            if (!_beerRepo.AddBeer(beer))
            {
                throw new Exception("Erreur lors de la sauvegarde de la bière");
            }
        }

        public bool IsBeerExist(int id)
        {
            return _beerRepo.IsBeerExist(id);
        }
        #endregion

        #region private method
        private List<BeerClient> ConvertBeerFromDB(List<Beer> beers)
        {
            List<BeerClient> beerClients = SetBeerClient(beers);
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
        #endregion
    }
}
