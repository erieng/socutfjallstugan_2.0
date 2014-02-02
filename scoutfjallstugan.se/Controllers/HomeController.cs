using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace scoutfjallstugan.se.Controllers
{
  public class HomeController : Controller
  {
    //[AllowAnonymous]
    public ActionResult Index()
    {
      ViewBag.Message = "Välkommen till Equmenia-scout i Fjällstugan!";

      return View();
    }

    public ActionResult About()
    {
      ViewBag.Message = "Your app description page.";
      

      return View();
    }

    public ActionResult Contact()
    {
      ViewBag.Message = "Your contact page.";

      return View();
    }
  }
}
