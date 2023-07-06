using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Models.AddModels
{
    public  class AddBeerModel
    {
        public string Name { get; set; }
        public double Degree { get; set; }
        public double Price { get; set; }
        public int BreweryId { get; set; }
    }
}
