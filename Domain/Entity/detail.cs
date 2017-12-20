using System;
using System.Collections.Generic;

namespace Domain.Entity
{
    public partial class details
    {
        public details()
        {
            this.claims = new List<claims>();
            this.exposures = new List<exposure>();
        }

        public int fk_artwork { get; set; }
        public System.DateTime detailDate { get; set; }
        public int fk_space { get; set; }
        public Nullable<int> exposure_id { get; set; }
        public virtual artwork artwork { get; set; }
        public virtual space space { get; set; }
        public virtual exposure exposure { get; set; }
        public virtual ICollection<claims> claims { get; set; }
        public virtual ICollection<exposure> exposures { get; set; }
    }
}
