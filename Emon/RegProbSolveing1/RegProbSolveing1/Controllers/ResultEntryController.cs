using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RegProbSolveing1.Models;

namespace RegProbSolveing1.Controllers
{
    public class ResultEntryController : Controller
    {
        private RegDbContext db = new RegDbContext();

        // GET: /ResultEntry/
        public ActionResult Index()
        {
            var resultentriedbset = db.ResultEntrieDbSet.Include(r => r.Course).Include(r => r.GradeLatter);
            return View(resultentriedbset.ToList());
        }

        // GET: /ResultEntry/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ResultEntry resultentry = db.ResultEntrieDbSet.Find(id);
            if (resultentry == null)
            {
                return HttpNotFound();
            }
            return View(resultentry);
        }

        // GET: /ResultEntry/Create
        public ActionResult Create()
        {
            ViewBag.CourseID = new SelectList(db.CourseDbSet, "CourseID", "CourseCode");
            ViewBag.GradeLatterId = new SelectList(db.GradeLatterDbSet, "GradeLatterId", "GradeLatterName");
            return View();
        }

        // POST: /ResultEntry/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ResultEntryId,CourseID,GradeLatterId")] ResultEntry resultentry)
        {
            if (ModelState.IsValid)
            {
                db.ResultEntrieDbSet.Add(resultentry);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CourseID = new SelectList(db.CourseDbSet, "CourseID", "CourseCode", resultentry.CourseID);
            ViewBag.GradeLatterId = new SelectList(db.GradeLatterDbSet, "GradeLatterId", "GradeLatterName", resultentry.GradeLatterId);
            return View(resultentry);
        }

        // GET: /ResultEntry/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ResultEntry resultentry = db.ResultEntrieDbSet.Find(id);
            if (resultentry == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseID = new SelectList(db.CourseDbSet, "CourseID", "CourseCode", resultentry.CourseID);
            ViewBag.GradeLatterId = new SelectList(db.GradeLatterDbSet, "GradeLatterId", "GradeLatterName", resultentry.GradeLatterId);
            return View(resultentry);
        }

        // POST: /ResultEntry/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ResultEntryId,CourseID,GradeLatterId")] ResultEntry resultentry)
        {
            if (ModelState.IsValid)
            {
                db.Entry(resultentry).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseID = new SelectList(db.CourseDbSet, "CourseID", "CourseCode", resultentry.CourseID);
            ViewBag.GradeLatterId = new SelectList(db.GradeLatterDbSet, "GradeLatterId", "GradeLatterName", resultentry.GradeLatterId);
            return View(resultentry);
        }

        // GET: /ResultEntry/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ResultEntry resultentry = db.ResultEntrieDbSet.Find(id);
            if (resultentry == null)
            {
                return HttpNotFound();
            }
            return View(resultentry);
        }

        // POST: /ResultEntry/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ResultEntry resultentry = db.ResultEntrieDbSet.Find(id);
            db.ResultEntrieDbSet.Remove(resultentry);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
