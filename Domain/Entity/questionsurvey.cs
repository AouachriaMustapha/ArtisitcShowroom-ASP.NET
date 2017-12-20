using System;
using System.Collections.Generic;

namespace Domain.Entity
{
    public partial class questionsurvey
    {
        public questionsurvey()
        {
            this.answersurveys = new List<answersurvey>();
        }

        public int id { get; set; }
        public bool answer { get; set; }
        public string question { get; set; }
        public Nullable<int> fk_survey { get; set; }
        public virtual ICollection<answersurvey> answersurveys { get; set; }
        public virtual survey survey { get; set; }
    }
}
