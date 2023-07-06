using _01_DB;
using _02_DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_DAL.Repositories
{
    public class WholesalerRepository : IWholesalerRepository
    {
        private readonly DataContext _context;

        public WholesalerRepository(DataContext context)
        {
            _context = context;
        }

        public bool IsWholesalerExist(int id)
        {
            bool exist = _context.wholesalers.Any(w => w.Id == id);

            return exist;
        }
    }
}
