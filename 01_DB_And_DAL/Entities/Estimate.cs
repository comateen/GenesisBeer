namespace _01_DB.Entities
{
    public class Estimate
    {
        public int Id { get; set; }
        public int WholesalerId { get; set; }
        
        public List<BeerEstimate> Beers { get; set; }
    }
}
