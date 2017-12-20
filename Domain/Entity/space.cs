using System;
using System.Collections.Generic;

namespace Domain.Entity
{
    public partial class space
    {
        public space()
        {
            this.details = new List<details>();
            this.exposures = new List<exposure>();
            this.users = new List<user>();
            this.rentspaces = new List<rentspace>();
        }

        public int id { get; set; }
        public string adress { get; set; }
        public string description { get; set; }
        public bool disponibility { get; set; }
        public byte[] file { get; set; }
        public Nullable<int> loulepar { get; set; }
        public string pic { get; set; }
        public string name { get; set; }
        public Nullable<DateTime> rentdate { get; set; }
        public float rentalPrice { get; set; }
        public Nullable<int> owner_id { get; set; }
        public virtual ICollection<details> details { get; set; }
        public virtual ICollection<exposure> exposures { get; set; }
        public virtual user user { get; set; }
        public virtual ICollection<user> users { get; set; }
        public virtual ICollection<rentspace> rentspaces { get; set; }
    }
}
