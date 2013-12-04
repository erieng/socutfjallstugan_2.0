using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using scoutfjallstugan.se.Models;
using System.Data;
using scoutfjallstugan.se.Filters;

namespace scoutfjallstugan.se.Controllers
{
  [Authorize]
  [InitializeSimpleMembership]

    public class MemberController : Controller
    {
        private ScoutDbContext db = new ScoutDbContext();

        //
        // GET: /Member/
        [ValidateAntiForgeryToken]
        public ActionResult Index()
        {
            return View(db.Members.ToList());
        }

        //
        // GET: /Member/Details/5
        [ValidateAntiForgeryToken]
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
       [ValidateAntiForgeryToken]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Member/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Member member)
        {
            if (ModelState.IsValid)
            {
                member.Id = Guid.NewGuid();
                db.Members.Add(member);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(member);
        }

        //
        // GET: /Member/Edit/5

        public ActionResult Edit(Guid id)
        {
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
            if (ModelState.IsValid)
            {
                db.Entry(member).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
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
            return RedirectToAction("Index");
        }

        public ActionResult SearchPatrol(string patrols, string name)
        {
          var PatrolLst = new List<string>();

          var PatrolQry = from d in db.Members
                         orderby d.PatrolName
                         select d.PatrolName;
          PatrolLst.AddRange(PatrolQry.Distinct());
          ViewBag.patrols = new SelectList(PatrolLst);

          var members = from m in db.Members
                       select m;

          if (!String.IsNullOrEmpty(name))
          {
            members = members.Where(s => s.FirstName.Contains(name));
          }

          if (string.IsNullOrEmpty(patrols))
            return View(members);
          else
          {
            return View(members.Where(x => x.PatrolName == patrols));
          }

        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}