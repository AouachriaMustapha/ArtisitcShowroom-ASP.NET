using Data.Models;
using Domain.Entity;
using System.Collections.Generic;
using System.Web.Mvc;

namespace WEB.Models
{
    public class SpaceViewModel
    {


       public SpaceViewModel()
        {
            this.users = new List<user>();


        }

        public int Id { get; set; }
        public string Adress { get; set; }
        public string Description { get; set; }
 
        public int Prix { get; set; }
        public string Urlimage { get; set; }

    

        public int fk_owner { get; set; }
        public virtual user user { get; set; }
        public virtual ICollection<user> users { get; set; }


    }






}