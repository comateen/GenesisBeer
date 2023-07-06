using _01_DB;
using _01_DB.Entities;
using _02_DAL.Interfaces;
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

        public bool UpdateWholesalerBeerToStock(StockBeerWholesaler stockBeerWolesaler)
        {
            _context.stockBeerWholesalers.Update(stockBeerWolesaler);
            return _context.SaveChanges() > 0;
        }
    }
}
