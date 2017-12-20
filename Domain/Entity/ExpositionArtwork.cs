using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class ExpositionArtwork
    {

        public int artworkId { get; set; }
        public int exposureId { get; set; }
        public virtual artwork Artwork { get; set; }
        public virtual exposure Exposure { get; set; }
        public int fk_space { get; set; }
        public int Priority { get; set; }
        public DateTime DateExpoPriority { get; set; }      
    }
}
