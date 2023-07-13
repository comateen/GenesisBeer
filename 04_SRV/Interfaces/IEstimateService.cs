using _03_Models.AddModels;
using _03_Models.VM;

namespace _04_SRV.Interfaces
{
    public interface IEstimateService
    {
        public bool AddEstimate(AddEstimateModel addEstimateModel);
        public EstimateOkReturn ManageEstimate(AddEstimateModel addEstimateModel);
    }
}
