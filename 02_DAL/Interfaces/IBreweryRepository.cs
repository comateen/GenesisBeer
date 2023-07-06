using _01_DB.Entities;

namespace _02_DAL.Interfaces
{
    public interface IBreweryRepository
    {
        public bool TryToGetAllBreweryData(out List<Brewery> beers);
        public bool IsBreweryExist(int id);
    }
}
