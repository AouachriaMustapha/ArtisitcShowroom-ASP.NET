using Data.Models;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEB.Models
{
    public class ExposureViewModel
    {

        public ExposureViewModel()
        {


        }
   public int id { get; set; }
        public string startdate { get; set; }
        public string enddate { get; set; }

        public Nullable<int> fk_survey { get; set; }
        public virtual ICollection<details> details { get; set; }
        public virtual survey survey { get; set; }
        public virtual ICollection<details> details1 { get; set; }



    }

}
