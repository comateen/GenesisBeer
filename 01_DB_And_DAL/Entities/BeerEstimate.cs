namespace _01_DB.Entities
{
    public class BeerEstimate
    {
        public int BeerId { get; set; }
        public int Quantity { get; set; }

        public int EstimateId { get; set; }
        public Estimate estimate { get; set; }
    }
}
