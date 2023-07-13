using _01_DB.Entities;

namespace _02_DAL.Interfaces
{
    public interface IStockBeerWholesalerRepository
    {
        public bool AddNewBeerToWholeSaler(StockBeerWholesaler stockBeerWolesaler);
        public bool UpdateStockBeerWholesaler(StockBeerWholesaler stockBeerWolesaler);
        public List<StockBeerWholesaler> GetAllStockBeerByWholesalerId(int id);
        public StockBeerWholesaler? GetStockBeerWholesalerByBeerIdAndWholesalerId(int beerId, int wholesalerId);
        public bool DeleteStockBeerWholesaler(StockBeerWholesaler stockBeerWolesaler);
    }
}
