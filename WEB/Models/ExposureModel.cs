using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Services;
using Domain.Entity;

namespace WEB.Models
{
    public class ExposureModel : IEnumerable
    {
        public int id { get; set; }
        public string name { get; set; }
        public DateTime? endDate { get; set; }
        public DateTime? startDate { get; set; }
        public string Order { get; set; }
        
        public virtual ICollection<ExpositionArtwork> ExpositionArtworks { get; set; }
       
        public virtual ICollection<ArtworkForExposureModel> Artworks { get; set; }
        public virtual ICollection<artwork> ArtworksOfArtist { get; set; }
        

        public virtual ICollection<ArtworkForExposureModel> ArtworkForExposureModels { get; set; }
        public  IEnumerable<SelectListItem> Spaces { get; set; }
        public virtual ICollection<details> details { get; set; }
        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}