using _03_Models.Models;

namespace _03_Models.VM
{
    public class BreweryWithBeersAndSalers : BreweryClient
    {
        public List<BeerClient> Beers { get; set; }

    }
}
