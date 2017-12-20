using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace MVC.Helpers
{
    public static class HelpMeSenpai
    {
        public static IEnumerable<SelectListItem> ToSelectListItems(
            this IEnumerable<space> Space)
        {
            return
                Space.OrderBy(cl => cl.id)
                    .Select(cl =>
                        new SelectListItem
                        {
                            
                            Text = "Space :" + cl.name ,
                            Value = cl.id.ToString()
                        });
        }
    }
}

      