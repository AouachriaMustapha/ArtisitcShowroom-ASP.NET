using System;
using System.Collections.Generic;

namespace Domain.Entity
{
    public partial class specialty
    {
        public specialty()
        {
            this.users = new List<user>();
        }

        public int id { get; set; }
        public string description { get; set; }
        public virtual ICollection<user> users { get; set; }
    }
}
