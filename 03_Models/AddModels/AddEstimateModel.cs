using _03_Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Models.AddModels
{
    public class AddEstimateModel
    {
        public int WholesalerId { get; set; }
        public List<BeerEstimateClient> Beers { get; set; }
    }
}
