namespace _03_Models.Models
{
    public class BeerClient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Degree { get; set; }
        public double Price { get; set; }
        public BreweryClient Brewery { get; set; }
        public List<WholesalerClient> Wholesalers { get; set; }
    }
}
