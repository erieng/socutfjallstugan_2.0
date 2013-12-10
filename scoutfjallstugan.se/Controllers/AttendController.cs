using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using scoutfjallstugan.se.Models;

namespace scoutfjallstugan.se.Controllers
{
    public class AttendController : Controller
    {
        private ScoutDbContext db = new ScoutDbContext();

        //
        // GET: /Attend/

        public ActionResult Index()
        {
            var attendies = db.Attendies.Include(a => a.Member).Include(a => a.Activity);
            return View(attendies.ToList());
        }

        //
        // GET: /Attend/Details/5

        public ActionResult Details(Guid id)
        {
            Attend attend = db.Attendies.Find(id);
            if (attend == null)
            {
                return HttpNotFound();
            }
            return View(attend);
        }

        //
        // GET: /Attend/Create

        public ActionResult Create()
        {
            ViewBag.MemberId = new SelectList(db.Members, "Id", "FirstName");
            ViewBag.ActivityId = new SelectList(db.Activities, "Id", "ActivityName");
            return View();
        }

        //
        // POST: /Attend/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Attend attend)
        {
            if (ModelState.IsValid)
            {
                attend.MemberId = Guid.NewGuid();
                db.Attendies.Add(attend);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MemberId = new SelectList(db.Members, "Id", "FirstName", attend.MemberId);
            ViewBag.ActivityId = new SelectList(db.Activities, "Id", "ActivityName", attend.ActivityId);
            return View(attend);
        }

        //
        // GET: /Attend/Edit/5

        public ActionResult Edit(Guid id)
        {
            Attend attend = db.Attendies.Find(id);
            if (attend == null)
            {
                return HttpNotFound();
            }
            ViewBag.MemberId = new SelectList(db.Members, "Id", "FirstName", attend.MemberId);
            ViewBag.ActivityId = new SelectList(db.Activities, "Id", "ActivityName", attend.ActivityId);
            return View(attend);
        }

        //
        // POST: /Attend/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Attend attend)
        {
            if (ModelState.IsValid)
            {
                db.Entry(attend).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MemberId = new SelectList(db.Members, "Id", "FirstName", attend.MemberId);
            ViewBag.ActivityId = new SelectList(db.Activities, "Id", "ActivityName", attend.ActivityId);
            return View(attend);
        }

        //
        // GET: /Attend/Delete/5

        public ActionResult Delete(Guid id)
        {
            Attend attend = db.Attendies.Find(id);
            if (attend == null)
            {
                return HttpNotFound();
            }
            return View(attend);
        }

        //
        // POST: /Attend/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Attend attend = db.Attendies.Find(id);
            db.Attendies.Remove(attend);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}