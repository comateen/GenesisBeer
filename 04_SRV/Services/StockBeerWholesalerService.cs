using _01_DB.Entities;
using _02_DAL.Interfaces;
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
    public class StockBeerWholesalerService : IStockBeerWholesalerService
    {
        #region private variable
        private readonly IBeerService _beerService;
        private readonly IWholesalerService _wholesalerService;
        private readonly IStockBeerWholesalerRepository _stockBeerRepository;

        public StockBeerWholesalerService(IBeerService beerService, IWholesalerService wholesalerService, IStockBeerWholesalerRepository stockBeerRepository)
        {
            _beerService = beerService;
            _wholesalerService = wholesalerService;
            _stockBeerRepository = stockBeerRepository;
        }
        #endregion

        #region public method
        public bool AddNewBeerToWholeSaler(StockBeerWholesalerClient stockBWS)
        {   
            if(IsBeerAndSalerExist(stockBWS.BeerId, stockBWS.WholesalerId))
            {
                if(stockBWS.Quantity < 0)
                {
                    throw new Exception("La quantité de bière ne peut être négative");
                }
                StockBeerWholesaler stockWBS_DB = ConvertStockClientToDB(stockBWS);

                _stockBeerRepository.AddNewBeerToWholeSaler(stockWBS_DB);

                return true;
            }
            return false;
        }

        

        public bool UpdateStockBeerWholesaler(StockBeerWholesalerClient stockBWS)
        {
            StockBeerWholesalerClient stockInDB = GetStockBeerWholesalerByBeerIdAndWholesalerId(stockBWS.BeerId, stockBWS.WholesalerId);
            if(stockInDB != null && stockBWS.Quantity >= 0)
            {
                if (stockInDB.Quantity != stockBWS.Quantity)
                {
                    stockInDB.Quantity = stockBWS.Quantity;
                    return _stockBeerRepository.UpdateStockBeerWholesaler(ConvertStockClientToDB(stockInDB));
                    //je fais la maj ici car si le stock est identique il est inutile de mettre à jour
                }
                return true;
            }

            throw new Exception("Le stock impossible à modifier");
        }
        public StockWholesaler GetAllStockBeerByWholesalerId(int id)
        {
            List<StockBeerWholesaler> stockDB = _stockBeerRepository.GetAllStockBeerByWholesalerId(id);
            if(stockDB == null)
            {
                throw new Exception("pas de stock trouvé pour le brasseur");
            }
            StockWholesaler stock = ConvertToStockWholesaler(stockDB, id);
            return stock;

        }

        public StockBeerWholesalerClient GetStockBeerWholesalerByBeerIdAndWholesalerId(int beerId, int wholesalerId)
        {
            StockBeerWholesaler stockBeerWholesaler = _stockBeerRepository.GetStockBeerWholesalerByBeerIdAndWholesalerId(beerId, wholesalerId);
            if(stockBeerWholesaler == null)
            {
                throw new Exception("cette référence n'existe pas");
            }
            return ConvertStockDBToClient(stockBeerWholesaler);
        }

        public bool DeleteStockBeerWholesaler(int beerId, int wholesalerId)
        {
            StockBeerWholesalerClient stockInDB = GetStockBeerWholesalerByBeerIdAndWholesalerId(beerId, wholesalerId);
            if (stockInDB == null || stockInDB.Quantity > 0)
            {
                throw new Exception("Le brasseur doit d'abord écouler son stock");
            }
            return _stockBeerRepository.DeleteStockBeerWholesaler(ConvertStockClientToDB(stockInDB));
            
        }

        #endregion

        #region private Method
        private bool IsBeerAndSalerExist(int beerId, int wholesalerId)
        {
            if (!_beerService.IsBeerExist(beerId))
            {
                throw new Exception("La bière que vous vouler ajouter n'existe pas");
            }
            if (!_wholesalerService.IsWholesalerExist(wholesalerId))
            {
                throw new Exception("Le brasseur n'existe pas");
            }
            return true;
        }
        private StockBeerWholesaler ConvertStockClientToDB(StockBeerWholesalerClient stockBWS)
        {
            StockBeerWholesaler stockWBS_DB = new StockBeerWholesaler();
            stockWBS_DB.WholesalerId = stockBWS.WholesalerId;
            stockWBS_DB.BeerId = stockBWS.BeerId;
            stockWBS_DB.Quantity = stockBWS.Quantity;

            return stockWBS_DB;
        }

        private StockBeerWholesalerClient ConvertStockDBToClient(StockBeerWholesaler stockBeerWholesaler)
        {
            StockBeerWholesalerClient stockBWS = new StockBeerWholesalerClient();
            stockBWS.BeerId = stockBeerWholesaler.BeerId;
            stockBWS.WholesalerId = stockBeerWholesaler.WholesalerId;
            stockBWS.Quantity = stockBeerWholesaler.Quantity;

            return stockBWS;
        }

        private StockWholesaler ConvertToStockWholesaler(List<StockBeerWholesaler> stockDB, int id)
        {
            StockWholesaler stockWholesaler = new StockWholesaler();
            stockWholesaler.Id = id;
            stockWholesaler.Name = stockDB.FirstOrDefault().Saler.Name;

            List<BeerToShow> beers = new List<BeerToShow>();
            foreach (var beerDB in stockDB)
            {
                BeerToShow beer = new BeerToShow();
                beer.Id = beerDB.BeerId;
                beer.Name = beerDB.beer.Name;
                beer.Price = beerDB.beer.Price;
                beer.Degree = beerDB.beer.Degree;
                beer.Quantity = beerDB.Quantity;

                stockWholesaler.Beers.Add(beer);
            }
            stockWholesaler.Beers = beers;
            
            return stockWholesaler;
        }
        #endregion
    }
}
