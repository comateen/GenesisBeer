using _03_Models.Models;

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
