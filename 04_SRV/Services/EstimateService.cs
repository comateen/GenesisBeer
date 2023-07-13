using _01_DB.Entities;
using _02_DAL.Interfaces;
using _03_Models.AddModels;
using _03_Models.Models;
using _03_Models.VM;
using _04_SRV.Interfaces;

namespace _04_SRV.Services
{
    public class EstimateService : IEstimateService
    {
        #region Private variable
        private readonly IStockBeerWholesalerService _stockBeerWholesalerService;
        private readonly IEstimateRepository _estimateRepository;

        public EstimateService(IStockBeerWholesalerService stockBeerWholesalerService, IEstimateRepository estimateRepository)
        {
            _stockBeerWholesalerService = stockBeerWholesalerService;
            _estimateRepository = estimateRepository;
        }
        #endregion

        #region public method
        public EstimateOkReturn ManageEstimate(AddEstimateModel addEstimateModel)
        {
            int totalQuantityBeer = 0;
            double totalPrice = 0;

            StockWholesaler? stockWholesaler = _stockBeerWholesalerService.GetAllStockBeerByWholesalerId(addEstimateModel.WholesalerId);
            if (stockWholesaler == null)
            {
                throw new Exception($"Le grossiste portant l'identifiant {addEstimateModel.WholesalerId} n'existe pas");
            }

            if (!CheckBasic(addEstimateModel.Beers, out string errorMessage))
            {
                throw new Exception(errorMessage);
            }

            List<BeerToShow> beersToShow = GetBeerstoShow(addEstimateModel.Beers, stockWholesaler.Beers, stockWholesaler.Name, ref totalPrice, ref totalQuantityBeer);


            EstimateOkReturn estimate = GetEstimateOkReturn(stockWholesaler.Id, stockWholesaler.Name, beersToShow, totalPrice, totalQuantityBeer);


            if (!AddEstimate(addEstimateModel))
            {
                throw new Exception("Problème lors de la sauvegarde du devis");
            }
            return estimate;
        }

        public bool AddEstimate(AddEstimateModel addEstimateModel)
        {
            Estimate estimate = new Estimate();
            estimate.WholesalerId = addEstimateModel.WholesalerId;
            List<BeerEstimate> beers = new List<BeerEstimate>();
            foreach (BeerEstimateClient beerTS in addEstimateModel.Beers)
            {
                BeerEstimate beer = new BeerEstimate();

                beer.BeerId = beerTS.BeerId;
                beer.Quantity = beerTS.Quantity;
                beers.Add(beer);
            }
            estimate.Beers = beers;

            if (_estimateRepository.AddEstimate(estimate))
            {
                return true;
            }
            return false;
        }
        #endregion

        #region private methode

        private bool CheckBasic(List<BeerEstimateClient> Beers, out string errorMessage)
        {
            errorMessage = string.Empty;
            if (Beers == null || Beers.Count <= 0)
            {
                errorMessage = "La commande est vide ou incomplète";
                return false;
            }
            bool anyDuplicate = Beers.GroupBy(b => b.BeerId).Any(g => g.Count() > 1);
            if (anyDuplicate)
            {
                errorMessage = "Vous commandez deux fois la même bière chez le même brasseur";
                return false;
            }
            return true;
        }
        private bool CheckBeers(BeerToShow? beer, BeerEstimateClient beerEstimate, out string errorMessage)
        {
            errorMessage = string.Empty;
            if (beer == null)
            {
                errorMessage = $" ne vend pas la bière portant l'identifiant {beerEstimate.BeerId}";
                return false;
            }
            if (beerEstimate.Quantity > beer.Quantity)
            {
                errorMessage = $" n'a pas assez de stock de bière {beer.Name}";
                return false;
            }
            return true;
        }

        private List<BeerToShow> GetBeerstoShow(List<BeerEstimateClient> beersClient, List<BeerToShow> beersInStok, string name, ref double totalPrice, ref int totalQuantityBeer)
        {
            List<BeerToShow> beersToShow = new List<BeerToShow>();
            foreach (BeerEstimateClient beerEstimate in beersClient)
            {
                BeerToShow? beer = beersInStok.FirstOrDefault(b => b.Id == beerEstimate.BeerId);
                if (!CheckBeers(beer, beerEstimate, out string errorMessage))
                {
                    throw new Exception($"Les grossiste {name} {errorMessage}");
                }

                beer.Quantity = beerEstimate.Quantity;
                beersToShow.Add(beer);

                double price = beerEstimate.Quantity * beer.Price;
                totalPrice += price;
                totalQuantityBeer += beerEstimate.Quantity;
            }
            return beersToShow;
        }
        private EstimateOkReturn GetEstimateOkReturn(int wholesalerId, string wholesalerName, List<BeerToShow> beersToShow, double totalPrice, int totalQuantityBeer)
        {
            EstimateOkReturn estimate = new EstimateOkReturn();

            estimate.Wholesaler = new WholesalerClient { Id = wholesalerId, Name = wholesalerName };

            estimate.Beers = beersToShow;

            estimate.TotalHTVA = DefineTotalHTVA(totalPrice, totalQuantityBeer);

            return estimate;
        }
        private double DefineTotalHTVA(double totalPrice, int totalQuantityBeer)
        {
            if (totalQuantityBeer > 20)
            {
                return totalPrice * 0.8;
            }
            else if (totalQuantityBeer > 10)
            {
                return totalPrice * 0.9;
            }
            else
            {
                return totalPrice;
            }
        }

        #endregion
    }
}
