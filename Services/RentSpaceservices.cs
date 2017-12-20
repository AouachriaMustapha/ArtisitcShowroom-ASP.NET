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
  public  class RentSpaceservices : Service<rentspace>
    {
        public static IDatabaseFactory dbf = new DatabaseFactory();
        public static IUnitOfWork ut = new UnitOfWork(dbf);
        public RentSpaceservices():base(ut)
        {
                    
        }

        public IEnumerable<rentspace> SpaceDisponibility(int id)
        {
            return ut.getRepository<rentspace>().GetMany(x => x.fk_space == id);

        }


    }
}
