using _01_DB.Entities;
using _03_Models.Models;
using _03_Models.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_SRV.Interfaces
{
    public interface IStockBeerWholesalerService
    {
        public bool AddNewBeerToWholeSaler(StockBeerWholesalerClient stockBWS);
        public bool UpdateStockBeerWholesaler(StockBeerWholesalerClient stockBWS);
        public StockWholesaler GetAllStockBeerByWholesalerId(int id);
        public StockBeerWholesalerClient GetStockBeerWholesalerByBeerIdAndWholesalerId(int beerId, int wholesalerId);
        public bool DeleteStockBeerWholesaler(int beerId, int wholesalerId);
    }
}
