using _01_DB.Entities;

namespace _02_DAL.Interfaces
{
    public interface IBreweryRepository
    {
        public List<Brewery> GetAllBreweryData();
        public bool IsBreweryExist(int id);
    }
}
