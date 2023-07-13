using _03_Models.Models;

namespace _03_Models.VM
{
    public class WholesalerWithBeer : WholesalerClient
    {
        public List<BeerToShow> Beers { get; set; }
    }
}
