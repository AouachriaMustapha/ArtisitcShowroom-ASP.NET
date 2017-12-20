using Data.Infrastructure;
using Domain.Entity;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
  public  class SpaceServices : Service<space>
    {
        private static IDatabaseFactory dbf = new DatabaseFactory();
        public static IUnitOfWork ut = new UnitOfWork(dbf);
        public SpaceServices() : base(ut)
        {
                    
        }


        public List<space> find(int id)
        {

            //return ut.getRepository<space>().GetMany(a => a. == id).ToList();)
            IEnumerable<details> D = ut.getRepository<details>().GetMany(a => a.exposure_id == id).ToList();
            List<space> S = new List<space>();
            foreach (details dt in D)
            {
                S.Add(this.GetById(dt.fk_space));
            }
            return S;
        }


        public List<String> AllAdress()
        {

            List<String> adre = new List<string>();
            var list = ut.getRepository<space>().GetMany().ToList();
            space s = null;
            foreach (space c in list)
            {
                adre.Add(c.adress);

            }

            return adre;
        }

        public int GetCountAddresse(string Add)
        {
            return ut.getRepository<space>().GetMany(a => a.adress == Add).Count();



        }

        public IEnumerable<space> GetAllSpaves()
        {
            return ut.getRepository<space>().GetMany();
        }

        public List<String> AllDateExposure()
        {

            List<String> date = new List<string>();
            var list = ut.getRepository<exposure>().GetMany().ToList();

            foreach (exposure c in list)
            {
                date.Add(c.startDate);

            }

            return date;
        }

    }
}
