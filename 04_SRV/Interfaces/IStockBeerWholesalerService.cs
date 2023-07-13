using _03_Models.Models;
using _03_Models.VM;

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
