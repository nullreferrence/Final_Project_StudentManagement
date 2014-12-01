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
    public class CourseController : Controller
    {
        private RegDbContext db = new RegDbContext();

        // GET: /Course/
        public ActionResult Index()
        {
            var coursedbset = db.CourseDbSet.Include(c => c.Department).Include(c => c.Semester);
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
            ViewBag.DepartmentID = new SelectList(db.DepartmentDbSet, "DepartmentID", "DeptCode");
            ViewBag.SemesterID = new SelectList(db.SemesterDbSet, "SemesterID", "SemesterName");
            return View();
        }

        // POST: /Course/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="CourseID,CourseCode,CourseName,Credit,Description,DepartmentID,SemesterID,AssignedTo")] Course course)
        {
            if (ModelState.IsValid)
            {
                db.CourseDbSet.Add(course);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DepartmentID = new SelectList(db.DepartmentDbSet, "DepartmentID", "DeptCode", course.DepartmentID);
            ViewBag.SemesterID = new SelectList(db.SemesterDbSet, "SemesterID", "SemesterName", course.SemesterID);
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
            ViewBag.DepartmentID = new SelectList(db.DepartmentDbSet, "DepartmentID", "DeptCode", course.DepartmentID);
            ViewBag.SemesterID = new SelectList(db.SemesterDbSet, "SemesterID", "SemesterName", course.SemesterID);
            return View(course);
        }

        // POST: /Course/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="CourseID,CourseCode,CourseName,Credit,Description,DepartmentID,SemesterID,AssignedTo")] Course course)
        {
            if (ModelState.IsValid)
            {
                db.Entry(course).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentID = new SelectList(db.DepartmentDbSet, "DepartmentID", "DeptCode", course.DepartmentID);
            ViewBag.SemesterID = new SelectList(db.SemesterDbSet, "SemesterID", "SemesterName", course.SemesterID);
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

        public JsonResult Check_CourseCode(string coursecode)
        {
            var Ccode = db.CourseDbSet.Count(c => c.CourseCode == coursecode) == 0;
            return Json(Ccode, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Check_CourseName(string coursename)
        {
            var Ccode = db.CourseDbSet.Count(c => c.CourseCode == coursename) == 0;
            return Json(Ccode, JsonRequestBehavior.AllowGet);
        }
    }
}
