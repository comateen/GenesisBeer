using _03_Models.AddModels;
using _03_Models.Models;
using _03_Models.VM;

namespace _04_SRV.Interfaces
{
    public interface IBeerService
    {
        public IEnumerable<BeerClient> GetAllBeerWithBrewerAndSalers();
        public void AddBeer(AddBeerModel addBeer);
        public bool IsBeerExist(int id);
        public BeerToShow GetOneBeerForEstimateReturn(int id);
    }
}
