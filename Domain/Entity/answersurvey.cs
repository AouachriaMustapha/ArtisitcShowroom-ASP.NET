using System;
using System.Collections.Generic;

namespace Domain.Entity
{
    public partial class answersurvey
    {
        public int id { get; set; }
        public string answer { get; set; }
        public Nullable<int> fk_questionsuervey { get; set; }
        public virtual questionsurvey questionsurvey { get; set; }
    }
}
