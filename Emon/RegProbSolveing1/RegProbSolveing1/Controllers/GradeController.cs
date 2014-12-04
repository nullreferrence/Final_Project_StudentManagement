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
    public class GradeController : Controller
    {
        private RegDbContext db = new RegDbContext();

        // GET: /Grade/
        public ActionResult Index()
        {
            return View(db.GradeLatterDbSet.ToList());
        }

        // GET: /Grade/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GradeLatter gradelatter = db.GradeLatterDbSet.Find(id);
            if (gradelatter == null)
            {
                return HttpNotFound();
            }
            return View(gradelatter);
        }

        // GET: /Grade/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Grade/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="GradeLatterId,GradeLatterName")] GradeLatter gradelatter)
        {
            if (ModelState.IsValid)
            {
                db.GradeLatterDbSet.Add(gradelatter);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gradelatter);
        }

        // GET: /Grade/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GradeLatter gradelatter = db.GradeLatterDbSet.Find(id);
            if (gradelatter == null)
            {
                return HttpNotFound();
            }
            return View(gradelatter);
        }

        // POST: /Grade/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="GradeLatterId,GradeLatterName")] GradeLatter gradelatter)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gradelatter).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gradelatter);
        }

        // GET: /Grade/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GradeLatter gradelatter = db.GradeLatterDbSet.Find(id);
            if (gradelatter == null)
            {
                return HttpNotFound();
            }
            return View(gradelatter);
        }

        // POST: /Grade/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GradeLatter gradelatter = db.GradeLatterDbSet.Find(id);
            db.GradeLatterDbSet.Remove(gradelatter);
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
