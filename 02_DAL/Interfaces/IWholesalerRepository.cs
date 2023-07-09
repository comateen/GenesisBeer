using _01_DB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_DAL.Interfaces
{
    public interface IWholesalerRepository
    {
        public bool GetOneWholesaler(int id, out Wholesaler wholesaler);
        public bool GetOneWholesalerWithBeer(int id, out Wholesaler wholesaler);
        public bool IsWholesalerExist(int id);
    }
}
