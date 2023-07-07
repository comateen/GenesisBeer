using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Models.VM
{
    public class EstimateOkReturn
    {
        public int Id { get; set; }
        public List<BeerByWholesalerForEstimateReturn> Beers { get; set; }
        public double? Total { get; set; }
    }
}
