using Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entity;
using ServicePattern;

namespace Services
{
   public class MettingServices : Service<metting>
    {
        private static IDatabaseFactory dbf = new DatabaseFactory();
        public static IUnitOfWork ut = new UnitOfWork(dbf);

        public MettingServices() :base(ut)
        {

        }
       

        public IEnumerable<metting> GetAlLMetting(int id)
        {
           return  ut.getRepository<metting>().GetMany(x=>x.fk_artist==id);
        
        }

        public IEnumerable<metting> GetAlLownerMetting(int id)
        {
            return ut.getRepository<metting>().GetMany(x => x.fk_owner == id);

        }


        public IEnumerable<metting> GetAllMettingbyowner(int id)
        {
           // user a = ut.getRepository<user>().GetById(id);
            return ut.getRepository<metting>().GetMany(v => v.fk_owner==id);

        }

        public IEnumerable<metting> RechercheA(string s, int id)
        {
            return ut.getRepository<metting>().GetMany(x => x.fk_artist == id && x.etat.Contains(s));
        }

        public IEnumerable<metting> GetAllMettingFromNow()
        {
            DateTime current = DateTime.Now;
            return ut.getRepository<metting>().GetMany(k=>k.mettingDate>current);
        }

        public IEnumerable<metting> GetOhistoryMetting(int id)
        {
            DateTime current = DateTime.Now;
            return ut.getRepository<metting>().GetMany(k => k.mettingDate < current && k.fk_owner==id);
        }
        public metting GetmettingByowner(int id)
        {
            return ut.getRepository<metting>().Get(x => x.fk_owner == id);
        }

       

        public void SaveChange()
        {
            ut.Commit();
        }
        public void Dispose()
        {
            ut.Dispose();
        }

       

        public metting Getmetting( int id1,int id2,string e,string p)
        {
            metting m = ut.getRepository<metting>().Get( x=>x.fk_artist==id1&&x.fk_owner==id2&&x.etat==e&&x.place==p);
            return m;
        }

        public IEnumerable<metting> GetCofirmedmetting(int id)
        {
            IEnumerable<metting> m = ut.getRepository<metting>().GetMany(x => x.fk_artist == id && x.etat.Equals("CONFIRMED"));
            return m;
        }
    }
}
