using System;
using System.Collections.Generic;

namespace Domain.Entity
{
    public partial class subscription
    {
        public int id { get; set; }
        public string datedebut { get; set; }
        public string datefin { get; set; }
        public string etat { get; set; }
        public float price { get; set; }
        public string type { get; set; }
        public Nullable<int> artist_id { get; set; }
        public virtual user user { get; set; }
    }
}
