using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
 public  partial class rentspace
    { 
     public int fk_artist { get; set; }
    public DateTime rentDate { get; set; }

    public int fk_space { get; set; }

    public float price { get; set; }
     public virtual space space { get; set; }
    public virtual user user { get; set; }
    public virtual user user1 { get; set; }
}
}
