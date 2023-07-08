using _01_DB;
using _01_DB.Entities;
using _02_DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
