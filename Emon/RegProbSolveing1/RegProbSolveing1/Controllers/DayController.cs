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
    public class DayController : Controller
    {
        private RegDbContext db = new RegDbContext();

        // GET: /Day/
        public ActionResult Index()
        {
            return View(db.DayDbSet.ToList());
        }

        // GET: /Day/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Days days = db.DayDbSet.Find(id);
            if (days == null)
            {
                return HttpNotFound();
            }
            return View(days);
        }

        // GET: /Day/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Day/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="DaysId,DaysName")] Days days)
        {
            if (ModelState.IsValid)
            {
                db.DayDbSet.Add(days);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(days);
        }

        // GET: /Day/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Days days = db.DayDbSet.Find(id);
            if (days == null)
            {
                return HttpNotFound();
            }
            return View(days);
        }

        // POST: /Day/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="DaysId,DaysName")] Days days)
        {
            if (ModelState.IsValid)
            {
                db.Entry(days).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(days);
        }

        // GET: /Day/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Days days = db.DayDbSet.Find(id);
            if (days == null)
            {
                return HttpNotFound();
            }
            return View(days);
        }

        // POST: /Day/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Days days = db.DayDbSet.Find(id);
            db.DayDbSet.Remove(days);
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
