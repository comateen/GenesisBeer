using _03_Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_SRV.Interfaces
{
    public interface IWholesalerService
    {
        public WholesalerClient GetOneWholesaler(int id);
        public bool IsWholesalerExist(int id);
    }
}
