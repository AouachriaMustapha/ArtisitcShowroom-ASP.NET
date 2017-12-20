using System;
using System.Collections.Generic;

namespace Domain.Entity
{
    public partial class exposure
    {
        public exposure()
        {
            this.artworks = new List<artwork>();
            this.details = new List<details>();
            this.artworks1 = new List<artwork>();
        }

        public int id { get; set; }
        public Nullable<System.DateTime> EDate { get; set; }
        public Nullable<System.DateTime> SDate { get; set; }
        public string endDate { get; set; }
        public string name { get; set; }
        public string startDate { get; set; }
        public Nullable<int> fk_space { get; set; }
        public Nullable<int> fk_survey { get; set; }
        public virtual ICollection<artwork> artworks { get; set; }
        public virtual ICollection<details> details { get; set; }
        public virtual survey survey { get; set; }
        public virtual space space { get; set; }
        public virtual ICollection<artwork> artworks1 { get; set; }
        public bool Archiver { get; set; }
        public virtual ICollection<ExpositionArtwork> ExpositionArtworks { get; set; }
    }
}
