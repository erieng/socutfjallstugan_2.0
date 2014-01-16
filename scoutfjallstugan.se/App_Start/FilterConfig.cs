﻿using System.Web;
using System.Web.Mvc;

namespace scoutfjallstugan.se
{
  public class FilterConfig
  {
    public static void RegisterGlobalFilters(GlobalFilterCollection filters)
    {
      filters.Add(new AuthorizeAttribute());
      filters.Add(new HandleErrorAttribute());

    }
  }
}