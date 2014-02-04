using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using scoutfjallstugan.se.Models;

namespace scoutfjallstugan.se.Controllers
{
  public class MemberController : Controller
  {
    private ScoutDbContext db = new ScoutDbContext();

    //
    // GET: /Member/

    public ActionResult Index()
    {
      return View(db.Members.ToList());
    }

    //
    // GET: /Member/Details/5

    public ActionResult Details(Guid id)
    {
      Member member = db.Members.Find(id);
      if (member == null)
      {
        return HttpNotFound();
      }
      return View(member);
    }

    //
    // GET: /Member/Create

    public ActionResult Create()
    {
      SetPatrolsViewBag();

      return View();
    }

    //
    // POST: /Member/Create

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(Member member)
    {
      SetPatrolsViewBag();

      if (ModelState.IsValid)
      {
        member.Id = Guid.NewGuid();
        db.Members.Add(member);
        db.SaveChanges();

       return RedirectToAction("SearchPatrol", ConvertToRouteArray());

       
      }

      return View(member);
    }

    //
    // GET: /Member/Edit/5

    public ActionResult Edit(Guid id)
    {
      SetPatrolsViewBag();

      Member member = db.Members.Find(id);
      if (member == null)
      {
        return HttpNotFound();
      }
      return View(member);
    }

    //
    // POST: /Member/Edit/5

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(Member member)
    {
      SetPatrolsViewBag();

      if (ModelState.IsValid)
      {
        db.Entry(member).State = EntityState.Modified;
        db.SaveChanges();
        return RedirectToAction("SearchPatrol", ConvertToRouteArray());
      }
      return View(member);
    }

    //
    // GET: /Member/Delete/5

    public ActionResult Delete(Guid id)
    {
      Member member = db.Members.Find(id);
      if (member == null)
      {
        return HttpNotFound();
      }
      return View(member);
    }

    //
    // POST: /Member/Delete/5

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(Guid id)
    {
      Member member = db.Members.Find(id);
      db.Members.Remove(member);
      db.SaveChanges();
      return RedirectToAction("SearchPatrol", ConvertToRouteArray());
    }

    public ActionResult SearchPatrol(string patrols, string name, bool? showLeader, bool? showInactive)
    {
      SetPatrolsViewBag();
      SetQueryParamsViewBag(patrols, name, showLeader, showInactive);

      var members = from m in db.Members
                    select m;

      if (showLeader == false || showLeader == null)
      {
        members = members.Where(s => s.IsLeader == false);
      }
      if (showInactive == false || showInactive == null)
      {
        members = members.Where(s => s.IsInactive == false);
      }

      if (!String.IsNullOrEmpty(name))
      {
        members = members.Where(s => s.FirstName.Contains(name) || s.LastName.Contains(name));
      }
      else
      {
        members = members.OrderBy(m => m.IsLeader).ThenBy(m => m.PatrolName).ThenBy(m => m.LastName);
      }

      if (string.IsNullOrEmpty(patrols))
      {
        return View(members.OrderBy(m => m.IsLeader).ThenBy(m => m.PatrolName).ThenBy(m => m.LastName));
      }
      else
      {
        return
          View(
            members.Where(x => x.PatrolName == patrols)
              .OrderBy(m => m.IsLeader).ThenBy(m => m.PatrolName)
              .ThenBy(m => m.LastName));
      }


    }

    public void SendEmail(string patrols, string includeLeader, string subject, string message)
    {

      SetPatrolsViewBag();

      var members = from m in db.Members
                    select m;

      if (includeLeader == "false" || includeLeader == "")
      {
        members = members.Where(s => s.IsLeader == false);
      }

      if (patrols != null)
      {
        members = members.Where(x => x.PatrolName == patrols)
              .OrderBy(m => m.IsLeader).ThenBy(m => m.PatrolName)
              .ThenBy(m => m.LastName);
      }


      SmtpClient scClient = new SmtpClient();
      scClient.Host = "mailout1.surf-town.net";
      scClient.Credentials = new System.Net.NetworkCredential("alltidredo@scoutfjallstugan.se", "allt1dr3d0");
    //  foreach (var member in members)
    //  {
        var email = new MailMessage();
        email.From = new MailAddress("scout@fjallstugan.se");
        email.To.Add(new MailAddress("erik@engvall.net, erik.engvall@hotmail.com"));
        email.Subject = "Testar";
        email.Body = "Hej!\nNu finns programmet för scout-terminen på fjallstugan.se under Equmenia - Scout.";
        
     // }
      scClient.Send(email);
    }

    private void SetPatrolsViewBag()
    {
      var patrolLst = new List<string>();

      var patrolQry = from d in db.Members
                      orderby d.PatrolName
                      select d.PatrolName;
      patrolLst.AddRange(patrolQry.Distinct());
      ViewBag.patrols = new SelectList(patrolLst);
    }

    private void SetQueryParamsViewBag(string patrols, string name, bool? showLeader, bool? showInactive)
    {
      ViewBag.queryParams = new {patrols = patrols, name = name, showLeader = showLeader, showInactive = showInactive};
    }


    private RouteValueDictionary ConvertToRouteArray()
    {
      var parsed = HttpUtility.ParseQueryString(string.Join(" ", Request.QueryString));
      Dictionary<string, object> querystringDic = parsed.AllKeys.ToDictionary(k => k, k => (object)parsed[k]);

      return new RouteValueDictionary(querystringDic);
    }

    protected override void Dispose(bool disposing)
    {
      db.Dispose();
      base.Dispose(disposing);
    }

    public ActionResult SendEmail(IEnumerable<Member> member)
    {
      foreach (var m in member)
      {

      }
      return null;
    }
  }
}