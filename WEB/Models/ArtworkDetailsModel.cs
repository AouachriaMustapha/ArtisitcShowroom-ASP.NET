using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEB.Models
{
    public class ArtworkDetailsModel
    {
        public int id { get; set; }
        public string description { get; set; }
        public string name { get; set; }
        public string photo { get; set; }
        public string NameArtist { get; set; }
        public string Category { set; get; }


    }
}