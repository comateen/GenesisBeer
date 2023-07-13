using _03_Models.VM;

namespace _04_SRV.Interfaces
{
    public interface IBreweryService
    {
        public IEnumerable<BreweryWithBeersAndSalers> GetAllBrewerWithBeerAndSalers();
        public bool IsBreweryExist(int id);
    }
}
