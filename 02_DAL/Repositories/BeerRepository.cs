using _01_DB;
using _01_DB.Entities;
using _02_DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace _02_DAL.Repositories
{
    public class BeerRepository : IBeerRepository
    {
        private readonly DataContext _context;
        
        public BeerRepository(DataContext context)
        {
            _context = context;
        }

        public List<Beer> GetAllBeerData()
        {
            List<Beer> beers = _context.beers.Include(b => b.Brewer)
                                  .Include(b => b.Wholesalers).ThenInclude(w => w.Saler).ToList();

            return beers;
        }
        public Beer? GetOneBeer(int id) 
        {
            Beer? beer = _context.beers.FirstOrDefault(b => b.Id == id);
            return beer;
        }
        public bool AddBeer(Beer beer)
        {
            _context.beers.Add(beer);
            return _context.SaveChanges() > 0;
        }

        public bool IsBeerExist(int id)
        {
            return _context.beers.Any(b => b.Id == id);
        }
    }
}
