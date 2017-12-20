using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
   public interface IMessageServices
    {
       

       
        IEnumerable<message> GetAlLMsgBysender(int id);
        IEnumerable<message> GetAllMsgbyreciever(int id);
    }
}
