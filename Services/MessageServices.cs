using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entity;
using Data.Infrastructure;
using ServicePattern;

namespace Services
{
    public class MessageServices : Service<message>
    {
        public static IDatabaseFactory dbf = new DatabaseFactory();
      public static  IUnitOfWork ut = new UnitOfWork(dbf);
        public MessageServices() :base(ut)
        {

        }
       

        public IEnumerable<message> GetAllMsgbyreciever(int id)
        {
           return ut.getRepository<message>().GetMany(x => x.idReceiver == id);
        }

        public IEnumerable<message> GetAlLMsgBysender(int id)
        {
            return ut.getRepository<message>().GetMany(x => x.idSender == id);
        }

        public IEnumerable<message> Recherche(string s,int id)
        {
            return ut.getRepository<message>().GetMany(x => x.idReceiver == id && x.subject.Contains(s));
        }





        public void SaveChange()
        {
            ut.Commit();
        }
        public void Dispose()
        {
            ut.Dispose();
        }

       
    }
}
