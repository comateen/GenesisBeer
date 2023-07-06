using _03_Models.Models;
using _03_Models.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_SRV.Interfaces
{
    public interface IBreweryService
    {
        public IEnumerable<BreweryWithBeersAndSalers> GetAllBrewerWithBeerAndSalers();
        public bool IsBreweryExist(int id);
    }
}
