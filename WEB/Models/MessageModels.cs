using Domain.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WEB.Models
{
    public class MessageModels
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idMessage { get; set; }
        public System.DateTime date { get; set; }
        public string text { get; set; }
        public string subject { get; set; }
        public Nullable<int> idSender { get; set; }
        public Nullable<int> idReceiver { get; set; }
        public virtual user user { get; set; }
        public virtual user user1 { get; set; }
        public int? UserId { get; set; }

        public IEnumerable<SelectListItem> users { get; set; }
    }
}