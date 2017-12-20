using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Data.Convention1
{
  public  class DatetimeConvention : Convention
    {
        public DatetimeConvention()
        {
            this.Properties<DateTime>().Configure(c => c.HasColumnType("datetime2"));

        }
    }
}
