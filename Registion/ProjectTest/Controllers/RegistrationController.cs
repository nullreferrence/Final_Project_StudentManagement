using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjectTest.Models;

namespace ProjectTest.Controllers
{
    public class RegistrationController : Controller
    {
        private ProjectDbContext db = new ProjectDbContext();

        // GET: /Registration/
        public ActionResult Index()
        {
            var aregistrations = db.ARegistrations.Include(r => r.ADepartment);
            return View(aregistrations.ToList());
        }

        // GET: /Registration/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Registration registration = db.ARegistrations.Find(id);
            if (registration == null)
            {
                return HttpNotFound();
            }
            return View(registration);
        }

        // GET: /Registration/Create
        public ActionResult Create()
        {
            ViewBag.DepartmentId = new SelectList(db.aDepartments, "DepartmentId", "Name");
            return View();
        }

        // POST: /Registration/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="RegistrationId,Name,Email,Contract_Number,Date,Address,DepartmentId")] Registration registration)
        {
            if (ModelState.IsValid)
            {
                db.ARegistrations.Add(registration);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DepartmentId = new SelectList(db.aDepartments, "DepartmentId", "Name", registration.DepartmentId);
            return View(registration);
        }

        // GET: /Registration/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Registration registration = db.ARegistrations.Find(id);
            if (registration == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmentId = new SelectList(db.aDepartments, "DepartmentId", "Name", registration.DepartmentId);
            return View(registration);
        }

        // POST: /Registration/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="RegistrationId,Name,Email,Contract_Number,Date,Address,DepartmentId")] Registration registration)
        {
            if (ModelState.IsValid)
            {
                db.Entry(registration).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentId = new SelectList(db.aDepartments, "DepartmentId", "Name", registration.DepartmentId);
            return View(registration);
        }

        // GET: /Registration/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Registration registration = db.ARegistrations.Find(id);
            if (registration == null)
            {
                return HttpNotFound();
            }
            return View(registration);
        }

        // POST: /Registration/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Registration registration = db.ARegistrations.Find(id);
            db.ARegistrations.Remove(registration);
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
