using _01_DB;
using _01_DB.Entities;
using _02_DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace _02_DAL.Repositories
{
    public class BreweryRepository : IBreweryRepository
    {
        private readonly DataContext _context;

        public BreweryRepository(DataContext context)
        {
            _context = context;
        }

        public List<Brewery> GetAllBreweryData()
        {
            List<Brewery> breweries = _context.breweries.Include(b => b.Beers)
                                          .ThenInclude(sbw => sbw.Wholesalers)
                                          .ThenInclude(w => w.Saler)
                                          .ToList();
            return breweries;
        }

        public bool IsBreweryExist(int id)
        {
            bool exist = _context.breweries.Any(b => b.Id == id);
            return exist;
        }
    }
}
