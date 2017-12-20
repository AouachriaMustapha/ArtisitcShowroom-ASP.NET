using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WEB.Models
{
    public class MettingModels
    {

        public MettingModels()
        {

            this.place = place;
        }

        public int fk_artist { get; set; }
        public DateTime mettingDate { get; set; }
        public int fk_owner { get; set; }
        public string place { get; set; }
        public string etat { get; set; }
        public int? UserId { get; set; }
        public user u { get; set; }

        public IEnumerable<SelectListItem> users { get; set; }
    }
}