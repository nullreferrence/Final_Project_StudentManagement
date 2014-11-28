using System;
using System.Collections.Generic;
//using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PzojectClassWordFriday.Models;

namespace PzojectClassWordFriday.Controllers
{
    public class CourseController : Controller
    {
        private UniDbContext db = new UniDbContext();

        // GET: /Course/
        public ActionResult Index()
        {
            var coursedbset = db.CourseDbSet.Include(c => c.Departments).Include(c => c.Semisters);
            return View(coursedbset.ToList());
        }

        // GET: /Course/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.CourseDbSet.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // GET: /Course/Create
        public ActionResult Create()
        {
            ViewBag.DepartmentId = new SelectList(db.DepartmentDbSet, "DepartmentId", "Code");
            ViewBag.SemisterId = new SelectList(db.SemisterDbSet, "SemisterId", "SemisterName");
            return View();
        }

        // POST: /Course/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="CourseId,CourseCode,CourseCredit,CourseName,Description,DepartmentId,SemisterId")] Course course)
        {
            if (ModelState.IsValid)
            {
                db.CourseDbSet.Add(course);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DepartmentId = new SelectList(db.DepartmentDbSet, "DepartmentId", "Code", course.DepartmentId);
            ViewBag.SemisterId = new SelectList(db.SemisterDbSet, "SemisterId", "SemisterName", course.SemisterId);
            return View(course);
        }

        // GET: /Course/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.CourseDbSet.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmentId = new SelectList(db.DepartmentDbSet, "DepartmentId", "Code", course.DepartmentId);
            ViewBag.SemisterId = new SelectList(db.SemisterDbSet, "SemisterId", "SemisterName", course.SemisterId);
            return View(course);
        }

        // POST: /Course/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="CourseId,CourseCode,CourseCredit,CourseName,Description,DepartmentId,SemisterId")] Course course)
        {
            if (ModelState.IsValid)
            {
                db.Entry(course).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentId = new SelectList(db.DepartmentDbSet, "DepartmentId", "Code", course.DepartmentId);
            ViewBag.SemisterId = new SelectList(db.SemisterDbSet, "SemisterId", "SemisterName", course.SemisterId);
            return View(course);
        }

        // GET: /Course/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.CourseDbSet.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // POST: /Course/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Course course = db.CourseDbSet.Find(id);
            db.CourseDbSet.Remove(course);
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
