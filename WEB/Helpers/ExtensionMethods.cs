using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WEB.Helpers
{
    public static class ExtensionMethods
    {
        public static IEnumerable<SelectListItem> ToSelectListItems(
              this IEnumerable<user> user)
        {
            return
                user.OrderBy(cl => cl.id)
                      .Select(cl =>
                          new SelectListItem
                          {
                              //     Selected = (prod.ProducteurId == selectedId),
                              Text = "Full Name :"+cl.firstName + " " + cl.lastName,
                              Value = cl.id.ToString()
                          });
        }

       
    }
}