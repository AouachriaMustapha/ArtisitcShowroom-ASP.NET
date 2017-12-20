using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Infrastructure;

using ServicePattern;
using Domain.Entity;

namespace Services
{
   public class CategoryService : Service<category>
    {

        public static DatabaseFactory dbf = new DatabaseFactory();
        public static UnitOfWork utw = new UnitOfWork(dbf);

       public CategoryService() : base(utw)
       {
           
       }

       public string GetCategoryById(int id)
       {
           int IdC = utw.getRepository<artwork>().GetById(id).category_id.Value;
           var x = utw.getRepository<category>().GetById(IdC);
           return x.description;
       }
    }
}
