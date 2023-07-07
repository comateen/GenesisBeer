using _03_Models.Models;
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
        public WholesalerClient Wholesaler { get; set; }
        public List<BeerToShow> Beers { get; set; }
        public double? TotalHTVA { get; set; }
    }
}
