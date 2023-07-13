using _01_DB.Entities;

namespace _02_DAL.Interfaces
{
    public interface IEstimateRepository
    {
        public bool AddEstimate(Estimate estimate);
    }
}
