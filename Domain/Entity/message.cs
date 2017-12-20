using System;
using System.Collections.Generic;

namespace Domain.Entity
{
    public partial class message
    {

        
        public int idMessage { get; set; }
        public System.DateTime date { get; set; }
        public string text { get; set; }
        public string subject { get; set; }
        public Nullable<int> idSender { get; set; }
        public Nullable<int> idReceiver { get; set; }
        public virtual user user { get; set; }
        public virtual user user1 { get; set; }
    }
}
