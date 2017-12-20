using System;
using System.Collections.Generic;

namespace Domain.Entity
{
    public partial class category
    {
        public category()
        {
            this.artworks = new List<artwork>();
            this.artworks1 = new List<artwork>();
        }

        public int id { get; set; }
        public string description { get; set; }
        public virtual ICollection<artwork> artworks { get; set; }
        public virtual ICollection<artwork> artworks1 { get; set; }
    }
}
