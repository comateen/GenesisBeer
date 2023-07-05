namespace _01_DB.Entities
{
    public class StockBeerWholesaler
    {
        public  int BeerId { get; set; }
        public Beer beer { get; set; }
        public int WholesalerId { get; set; }
        public Wholesaler Saler { get; set; }
        public int Quantity { get; set; }
    }
}
