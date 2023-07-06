﻿using _01_DB;
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
        
        public bool TryToGetAllBeerData(out List<Beer> beers)
        {
            beers = _context.beers.Include(b => b.Brewer)
                                  .Include(b => b.Wholesalers).ThenInclude(w => w.Saler).ToList();

            return beers.Any();
        }
    }
}