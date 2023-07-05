namespace _01_DB.Entities
{
    public class Beer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Degree { get; set; }
        public float Price { get; set; }
        //One-to-Many
        public int BreweryId { get; set; }
        public Brewery Brewer { get; set; }
        //ajouter dans Brewery le liens necessaire

        public List<StockBeerWholesaler> Wholesalers { get; set; }
    }
}
