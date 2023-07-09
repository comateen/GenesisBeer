using _01_DB.Entities;
using _02_DAL.Interfaces;
using _03_Models.Models;
using _03_Models.VM;
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

        public WholesalerClient GetOneWholesaler(int id)
        {
            Wholesaler wholesalerDB; 
            if(_wholesalerRepository.GetOneWholesaler(id, out wholesalerDB))
            {
                WholesalerClient wholesaler = new WholesalerClient();
                wholesaler.Id = wholesalerDB.Id;
                wholesaler.Name = wholesalerDB.Name;
                return wholesaler;
            }
            throw new Exception("Le grosiste rechercher n'existe pas");
        }

        public bool IsWholesalerExist(int id)
        {
            return _wholesalerRepository.IsWholesalerExist(id);
        }
    }
}
