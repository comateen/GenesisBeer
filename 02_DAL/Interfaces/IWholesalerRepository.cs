using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_DAL.Interfaces
{
    public interface IWholesalerRepository
    {
        public bool IsWholesalerExist(int id);
    }
}
