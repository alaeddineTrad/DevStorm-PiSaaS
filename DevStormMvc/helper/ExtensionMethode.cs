using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DevStormMvc.helper
{
    public static class ExtensionMethode
    {
        public static IEnumerable<SelectListItem>
             ToSelectShowroomer(this IEnumerable<Showroomer> name)
        {
            return name.OrderBy(c => c.UserId).Select(r =>
                   new SelectListItem
                   {
                       Text = r.FirstName,
                       Value = r.UserId.ToString()
                }
            );
        }
        public static IEnumerable<SelectListItem>
        ToSelectUser(this IEnumerable<User> name)
        {
            return name.OrderBy(c => c.UserId).Select(r =>
              new SelectListItem
              {
                  Text = r.FirstName,
                  Value = r.UserId.ToString()
              }
            );
        }
        public static IEnumerable<SelectListItem>
        ToSelectProduct(this IEnumerable<Product> name)
        {
            return name.OrderBy(c => c.ProductId).Select(r =>
              new SelectListItem
              {
                  Text = r.Name,
                  Value = r.ProductId.ToString()
              }
            );
        }
    }
}