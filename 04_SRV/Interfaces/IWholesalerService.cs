using _03_Models.Models;

namespace _04_SRV.Interfaces
{
    public interface IWholesalerService
    {
        public WholesalerClient GetOneWholesaler(int id);
        public bool IsWholesalerExist(int id);
    }
}
