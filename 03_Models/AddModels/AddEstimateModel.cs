using _03_Models.Models;

namespace _03_Models.AddModels
{
    public class AddEstimateModel
    {
        public int WholesalerId { get; set; }
        public List<BeerEstimateClient> Beers { get; set; }
    }
}
