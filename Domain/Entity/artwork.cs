using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entity
{
    public partial class artwork
    {
        public artwork()
        {
            this.details = new List<details>();
            this.categories = new List<category>();
            this.exposures = new List<exposure>();
            this.users = new List<user>();
        }

        public int id { get; set; }
        public string description { get; set; }
        public string name { get; set; }
        public byte[] photo { get; set; }
        [StringLength(255)]
        public string phot { get; set; }
        public float price { get; set; }
        public Nullable<int> artist_id { get; set; }
        public Nullable<int> bookingPurchasing_id { get; set; }
        public Nullable<int> category_id { get; set; }
        public Nullable<int> fk_exposure { get; set; }
        public virtual ICollection<details> details { get; set; }
        public virtual user user { get; set; }
        public virtual bookingpurchasing bookingpurchasing { get; set; }
        public virtual category category { get; set; }
        public virtual exposure exposure { get; set; }
        public virtual ICollection<category> categories { get; set; }
        public virtual ICollection<exposure> exposures { get; set; }
        public virtual ICollection<user> users { get; set; }
    }
}
