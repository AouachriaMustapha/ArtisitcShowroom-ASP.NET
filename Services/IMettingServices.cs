using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
  public  interface IMettingServices
    {
        void AddMetting(metting m);
        void SuppMetting(metting mett);
        void UppMetting(metting m);
        IEnumerable<metting> GetAllMettingFromNow();
        IEnumerable<metting> GetAlLMetting(int id);
        IEnumerable<metting> GetAllMettingbyowner(int id);
        metting GetmettingByowner(int id);
        metting Getmettingbyid(int idA, DateTime d, int idO, string p);

    }
}
