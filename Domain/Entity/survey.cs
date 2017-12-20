using System;
using System.Collections.Generic;

namespace Domain.Entity
{
    public partial class survey
    {
        public survey()
        {
            this.exposures = new List<exposure>();
            this.questionsurveys = new List<questionsurvey>();
        }

        public int id { get; set; }
        public string name { get; set; }
        public string note { get; set; }
        public virtual ICollection<exposure> exposures { get; set; }
        public virtual ICollection<questionsurvey> questionsurveys { get; set; }
    }
}
