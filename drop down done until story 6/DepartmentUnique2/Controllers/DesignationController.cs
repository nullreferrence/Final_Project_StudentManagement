using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DepartmentUnique2.Models;

namespace DepartmentUnique2.Controllers
{
    public class DesignationController : Controller
    {
        private TestDBcontext db = new TestDBcontext();

        // GET: /Designation/
        public ActionResult Index()
        {
            return View(db.DesignationDbSet.ToList());
        }

        // GET: /Designation/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Designation designation = db.DesignationDbSet.Find(id);
            if (designation == null)
            {
                return HttpNotFound();
            }
            return View(designation);
        }

        // GET: /Designation/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Designation/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="DesignationId,DesignationName")] Designation designation)
        {
            if (ModelState.IsValid)
            {
                db.DesignationDbSet.Add(designation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(designation);
        }

        // GET: /Designation/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Designation designation = db.DesignationDbSet.Find(id);
            if (designation == null)
            {
                return HttpNotFound();
            }
            return View(designation);
        }

        // POST: /Designation/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="DesignationId,DesignationName")] Designation designation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(designation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(designation);
        }

        // GET: /Designation/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Designation designation = db.DesignationDbSet.Find(id);
            if (designation == null)
            {
                return HttpNotFound();
            }
            return View(designation);
        }

        // POST: /Designation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Designation designation = db.DesignationDbSet.Find(id);
            db.DesignationDbSet.Remove(designation);
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
