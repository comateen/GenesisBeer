namespace _01_DB.Entities
{
    public class Wholesaler
    {
        public int Id { get; set; }
        public  string Name { get; set; }
        public List<StockBeerWholesaler> Beers { get; set; }
    }
}
