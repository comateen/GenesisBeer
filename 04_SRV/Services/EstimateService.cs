using _01_DB.Entities;
using _02_DAL.Interfaces;
using _03_Models.AddModels;
using _03_Models.Models;
using _03_Models.VM;
using _04_SRV.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_SRV.Services
{
    public class EstimateService : IEstimateService
    {
        #region Private variable
        private readonly IWholesalerService _wholesalerService;
        private readonly IBeerService _beerService;
        private readonly IStockBeerWholesalerService _stockBeerWholesalerService;
        private readonly IEstimateRepository _estimateRepository;

        public EstimateService(IWholesalerService wholesalerService, IBeerService beerService, IStockBeerWholesalerService stockBeerWholesalerService, IEstimateRepository estimateRepository)
        {
            _wholesalerService = wholesalerService;
            _beerService = beerService;
            _stockBeerWholesalerService = stockBeerWholesalerService;
            _estimateRepository = estimateRepository;
        }
        #endregion

        #region public method
        public EstimateOkReturn ManageEstimate(AddEstimateModel addEstimateModel)
        {
            int totalQuantityBeer = 0;
            double totalPrice = 0;

            StockWholesaler stockWholesaler = _stockBeerWholesalerService.GetAllStockBeerByWholesalerId(addEstimateModel.WholesalerId);
            if (stockWholesaler == null)
            {
                throw new Exception($"Le grossiste portant l'identifiant {addEstimateModel.WholesalerId} n'existe pas");
            }
            string errorMessage;
            if (!CheckBasic(addEstimateModel,out errorMessage))
            {
                throw new Exception(errorMessage);
            }
            //je préfère rassembler toute les infos en une fois plutot que de procéder à un call db dans un foreach, question dep erformence même si 
            //à cette échelle ça n'a que peut d'influence
            List<BeerToShow> beersToShow = new List<BeerToShow>();
            foreach (var beerEstimate in addEstimateModel.Beers)
            {
                //si je procède comme suit j'ai un call DB pour chaque itération de mon foreach
                //BeerToShow beer = _beerService.GetOneBeerForEstimateReturn(beerEstimate.BeerId);
                BeerToShow beer = stockWholesaler.Beers.FirstOrDefault(b => b.Id == beerEstimate.BeerId);

                if (beer == null)
                {
                    throw new Exception($"Le grossiste {stockWholesaler.Name} ne vend pas la bière portant l'identifiant {beerEstimate.BeerId}");
                }
                if (beerEstimate.Quantity > beer.Quantity)
                {
                    throw new Exception($"Le grossiste {stockWholesaler.Name} n'a pas assez de stock de bière {beer.Name}");
                }

                beer.Quantity = beerEstimate.Quantity;
                beersToShow.Add(beer);
                double price = beerEstimate.Quantity * beer.Price;
                totalPrice += price;
                totalQuantityBeer += beerEstimate.Quantity;
            }

            EstimateOkReturn estimate = new EstimateOkReturn();
            estimate.Wholesaler.Id = stockWholesaler.Id;
            estimate.Wholesaler.Name = stockWholesaler.Name;
            estimate.Beers = beersToShow;

            estimate.TotalHTVA = DefineTotalHTVA(totalPrice, totalQuantityBeer);
            
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
            foreach(BeerEstimateClient beerTS in addEstimateModel.Beers)
            {
                BeerEstimate beer = new BeerEstimate();

                beer.BeerId = beerTS.BeerId;
                beer.Quantity = beerTS.Quantity;
                beers.Add(beer);
            }
            estimate.Beers = beers;

            if(_estimateRepository.AddEstimate(estimate))
            {
                return true;
            }
            return false;
        }
        #endregion

        #region private methode

        private bool CheckBasic(AddEstimateModel addEstimateModel, out string errorMessage)
        {
            errorMessage = string.Empty;
            if (addEstimateModel == null || addEstimateModel.Beers == null || addEstimateModel.Beers.Count <= 0)
            {
                errorMessage = "La commande est vide ou incomplète";
                return false;
            }
            bool anyDuplicate = addEstimateModel.Beers.GroupBy(b => b.BeerId).Any(g => g.Count() > 1);
            if (anyDuplicate)
            {
                errorMessage = "Vous commandez deux fois la même bière chez le même brasseur";
                return false;
            }
            return true;
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
