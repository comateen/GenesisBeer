using _03_Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Models.VM
{
    public class BeerByWholesalerForEstimateReturn
    {
        public WholesalerClient Wholesaler { get; set; }
        public List<BeerClient> Beers { get; set; }
    }
}
