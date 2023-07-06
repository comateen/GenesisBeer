using _03_Models.AddModels;
using _03_Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_SRV.Interfaces
{
    public interface IBeerService
    {
        public IEnumerable<BeerClient> GetAllBeerWithBrewerAndSalers();
        public void AddBeer(AddBeerModel addBeer);
        public bool IsBeerExist(int id);
    }
}
