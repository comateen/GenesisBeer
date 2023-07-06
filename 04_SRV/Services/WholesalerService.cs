using _02_DAL.Interfaces;
using _04_SRV.Interfaces;

namespace _04_SRV.Services
{
    public class WholesalerService : IWholesalerService
    {
        private readonly IWholesalerRepository _wholesalerRepository;

        public WholesalerService(IWholesalerRepository wholesalerRepository)
        {
            _wholesalerRepository = wholesalerRepository;
        }

        public bool IsWholesalerExist(int id)
        {
            return _wholesalerRepository.IsWholesalerExist(id);
        }
    }
}
