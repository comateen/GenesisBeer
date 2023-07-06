using _01_DB;
using _01_DB.Entities;
using _02_DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_DAL.Repositories
{
    public class BreweryRepository : IBreweryRepository
    {
        private readonly DataContext _context;

        public BreweryRepository(DataContext context)
        {
            _context = context;
        }

        public bool TryToGetAllBreweryData(out List<Brewery> breweries)
        {
            breweries = _context.breweries.Include(b => b.Beers)
                                          .ThenInclude(sbw => sbw.Wholesalers)
                                          .ThenInclude(w => w.Saler)
                                          .ToList();
            return breweries.Any();
        }
    }
}
