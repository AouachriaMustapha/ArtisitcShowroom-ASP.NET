using System;
using System.Collections.Generic;

namespace Domain.Entity
{
    public partial class metting
    {

        public metting()
        {

            
        }
        
        public int fk_artist { get; set; }
        public DateTime mettingDate { get; set; }
        public int fk_owner { get; set; }
        public string etat { get; set; }
        public string place { get; set; }
        public virtual user user { get; set; }
        public virtual user user1 { get; set; }
    }
}
