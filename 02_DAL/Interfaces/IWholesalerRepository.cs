using _01_DB.Entities;

namespace _02_DAL.Interfaces
{
    public interface IWholesalerRepository
    {
        public Wholesaler? GetOneWholesaler(int id);
        public Wholesaler? GetOneWholesalerWithBeer(int id);
        public bool IsWholesalerExist(int id);
    }
}
