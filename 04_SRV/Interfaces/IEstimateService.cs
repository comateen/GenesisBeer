using _03_Models.AddModels;
using _03_Models.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_SRV.Interfaces
{
    public interface IEstimateService
    {
        public bool AddEstimate(AddEstimateModel addEstimateModel);
        public EstimateOkReturn ManageEstimate(AddEstimateModel addEstimateModel);
    }
}
