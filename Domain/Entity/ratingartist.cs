using System;
using System.Collections.Generic;

namespace Domain.Entity
{
    public partial class ratingartist
    {
        public int id_artist { get; set; }
        public int id_client { get; set; }
        public double mark { get; set; }
        public double result { get; set; }
        public virtual user user { get; set; }
        public virtual user user1 { get; set; }
    }
}
