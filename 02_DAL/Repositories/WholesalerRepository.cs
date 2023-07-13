using _01_DB;
using _01_DB.Entities;
using _02_DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace _02_DAL.Repositories
{
    public class WholesalerRepository : IWholesalerRepository
    {
        private readonly DataContext _context;

        public WholesalerRepository(DataContext context)
        {
            _context = context;
        }

        public Wholesaler? GetOneWholesaler(int id)
        {
            Wholesaler? wholesaler = _context.wholesalers.FirstOrDefault(w => w.Id == id);
            return wholesaler;
        }
        public Wholesaler? GetOneWholesalerWithBeer(int id)
        {
            Wholesaler? wholesaler = _context.wholesalers.Where(w => w.Id == id)
                                             .Include(w => w.Beers)
                                             .FirstOrDefault();
            return wholesaler;
        }
        public bool IsWholesalerExist(int id)
        {
            bool exist = _context.wholesalers.Any(w => w.Id == id);

            return exist;
        }
    }
}
