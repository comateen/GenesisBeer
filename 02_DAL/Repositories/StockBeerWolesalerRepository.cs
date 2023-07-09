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
    public class StockBeerWolesalerRepository : IStockBeerWholesalerRepository
    {
        private readonly DataContext _context;

        public StockBeerWolesalerRepository(DataContext context)
        {
            _context = context;
        }

        public bool AddNewBeerToWholeSaler(StockBeerWholesaler stockBeerWolesaler)
        {
            _context.stockBeerWholesalers.Add(stockBeerWolesaler);
            return _context.SaveChanges() > 0;
        }

        public List<StockBeerWholesaler> GetAllStockBeerByWholesalerId(int id)
        {
            return _context.stockBeerWholesalers.Where(sbw => sbw.WholesalerId == id)
                                                .Include(b => b.beer).ThenInclude(w => w.Wholesalers)
                                                .ToList();                              
        }

        public StockBeerWholesaler GetStockBeerWholesalerByBeerIdAndWholesalerId(int beerId, int wholesalerId)
        {
            //return _context.stockBeerWholesalers.FirstOrDefault(sbw => sbw.BeerId == beerId && sbw.WholesalerId == wholesalerId);
            return _context.stockBeerWholesalers.AsNoTracking().FirstOrDefault(sbw => sbw.BeerId == beerId && sbw.WholesalerId == wholesalerId);
            //attention le AsNoTracking risque de faire planter les Unit test
        }

        public bool UpdateStockBeerWholesaler(StockBeerWholesaler stockBeerWolesaler)
        {
            _context.stockBeerWholesalers.Update(stockBeerWolesaler);
            return _context.SaveChanges() > 0;
        }

        public bool DeleteStockBeerWholesaler(StockBeerWholesaler stockBeerWolesaler)
        {
            _context.stockBeerWholesalers.Remove(stockBeerWolesaler);
            return _context.SaveChanges() > 0;
        }
    }
}
