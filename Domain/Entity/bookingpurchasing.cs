using System;
using System.Collections.Generic;

namespace Domain.Entity
{
    public partial class bookingpurchasing
    {
        public bookingpurchasing()
        {
            this.artworks = new List<artwork>();
            this.users = new List<user>();
        }

        public int id { get; set; }
        public float advencePayement { get; set; }
        public Nullable<System.DateTime> bookingDate { get; set; }
        public Nullable<System.DateTime> purchasingDate { get; set; }
        public Nullable<int> fk_client { get; set; }
        public virtual ICollection<artwork> artworks { get; set; }
        public virtual user user { get; set; }
        public virtual ICollection<user> users { get; set; }
    }
}
