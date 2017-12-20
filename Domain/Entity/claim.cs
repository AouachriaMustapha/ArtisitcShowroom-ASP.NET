using System;
using System.Collections.Generic;

namespace Domain.Entity
{
    public partial class claims
    {
        public claims()
        {
            this.details = new List<details>();
        }

        public int id { get; set; }
        public string subject { get; set; }

        public string name { get; set; }
        public virtual ICollection<details> details { get; set; }
    }
}
