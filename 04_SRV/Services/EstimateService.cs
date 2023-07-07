﻿using _01_DB.Entities;
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
            WholesalerClient wholesaler = _wholesalerService.GetOneWholesaler(addEstimateModel.WholesalerId);
            if(addEstimateModel == null || addEstimateModel.Beers == null || addEstimateModel.Beers.Count <= 0)
            {
                throw new ArgumentException("La commande est vide ou incomplète");
            }
            bool anyDuplicate = addEstimateModel.Beers.GroupBy(b => b.BeerId).Any(g => g.Count() > 1);
            if(anyDuplicate)
            {
                throw new ArgumentException("Vous commandez deux fois la même bière chez le même brasseur");
            }
            if (wholesaler == null)
            {
                throw new Exception($"Le grossiste portant l'identifiant {addEstimateModel.WholesalerId} n'existe pas");
            }
            List<BeerToShow> beersToShow = new List<BeerToShow>();
            foreach (var beerEstimate in addEstimateModel.Beers)
            {
                BeerToShow beer = _beerService.GetOneBeerForEstimateReturn(beerEstimate.BeerId);
                if (beer == null)
                {
                    throw new Exception($"La bière portant l'identifiant {beerEstimate.BeerId} n'existe pas");
                }
                StockBeerWholesalerClient stockBeerWholesaler = _stockBeerWholesalerService.GetStockBeerWholesalerByBeerIdAndWholesalerId(beerEstimate.BeerId, addEstimateModel.WholesalerId);
                if (stockBeerWholesaler == null)
                {
                    throw new Exception($"Le grossiste {wholesaler.Name} ne vend pas la bière {beer.Name}");
                }
                if(beerEstimate.Quantity > stockBeerWholesaler.Quantity)
                {
                    throw new Exception($"Le grossiste {wholesaler.Name} n'a pas assez de stock de bière {beer.Name}");
                }

                beer.Quantity = beerEstimate.Quantity;
                beersToShow.Add(beer);
                double price = beerEstimate.Quantity * beer.Price;
                totalPrice += price;
                totalQuantityBeer += beerEstimate.Quantity;
            }

            EstimateOkReturn estimate = new EstimateOkReturn();
            estimate.Wholesaler = wholesaler;
            estimate.Beers = beersToShow;

            if(totalQuantityBeer > 20) 
            {
                estimate.TotalHTVA = totalPrice * 0.8;
            } 
            else if (totalQuantityBeer > 10) 
            {
                estimate.TotalHTVA = totalPrice * 0.9;
            }
            else
            {
                estimate.TotalHTVA = totalPrice;
            }

            return estimate;
        }
        public bool AddEstimate(AddEstimateModel addEstimateModel)
        {
            throw new NotImplementedException();
        }
        #endregion

    }
}