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
  public  class UserServices :Service<user> ,  IUserServices
    {
        
        private static IDatabaseFactory dbf = new DatabaseFactory();
         public static  IUnitOfWork ut = new UnitOfWork(dbf);

        public UserServices():base(ut)
        {
                            
        }

        public IEnumerable<user> GetAllOwners()
        {
            return ut.getRepository<user>().GetMany(x=>x.type.Equals("owner"));
        }

        //public user login()
     //   {
     //       var user = .users.Where(model => model.login.Equals(u.login) && model.password.Equals(u.password)).FirstOrDefault();
     //   }
        
        public user GetuserbyLogin(string firstname)
        {
            return ut.getRepository<user>().Get(x => x.firstName == firstname);
        }


        public string GetArtistByArtworkId(int idc)
        {
            int IdU = ut.getRepository<artwork>().GetById(idc).artist_id.Value;
            var v = ut.getRepository<user>().GetById(IdU);
            return v.firstName;
        }
    }
}
