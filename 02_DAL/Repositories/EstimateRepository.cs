using _01_DB;
using _01_DB.Entities;
using _02_DAL.Interfaces;

namespace _02_DAL.Repositories
{
    public class EstimateRepository : IEstimateRepository
    {
        private readonly DataContext _context;

        public EstimateRepository(DataContext context)
        {
            _context = context;
        }

        public bool AddEstimate(Estimate estimate)
        {
            _context.estimates.Add(estimate);
            return _context.SaveChanges() > 0;
        }
    }
}
