using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEB.Models
{
    public class ArtworkForExposureModel
    {
        public int id { get; set; }

        public string name { get; set; }
        public string photo { get; set; }
        public int FkSpace { get; set; }
        public string Order { get; set; }
        public int Priority { get; set; }
        public string ArtistName { get; set; }
        public string SpaceName { get; set; }
        public string SpaceAddress { get; set; }
        public string OwnerName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int IdExpo { get; set; }
    }
}