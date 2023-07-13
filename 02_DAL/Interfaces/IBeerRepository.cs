using _01_DB.Entities;

namespace _02_DAL.Interfaces
{
    public interface IBeerRepository
    {
        public List<Beer> GetAllBeerData();
        public bool AddBeer(Beer beer);
        public bool IsBeerExist(int id);
        public Beer? GetOneBeer(int id);
    }
}
