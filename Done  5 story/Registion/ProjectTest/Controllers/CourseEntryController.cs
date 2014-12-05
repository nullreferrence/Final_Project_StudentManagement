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
    public class CourseEntryController : Controller
    {
        private ProjectDbContext db = new ProjectDbContext();

        // GET: /CourseEntry/
        public ActionResult Index()
        {
            var acourses = db.aCourses.Include(c => c.Departments).Include(c => c.Semesters);
            return View(acourses.ToList());
        }

        // GET: /CourseEntry/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.aCourses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // GET: /CourseEntry/Create
        public ActionResult Create()
        {
            ViewBag.DepartmentId = new SelectList(db.aDepartments, "DepartmentId", "Code");
            ViewBag.SemesterId = new SelectList(db.aSemesters, "SemesterId", "SemesterName");
            return View();
        }

        // POST: /CourseEntry/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="CourseId,CourseCode,CourseCredit,CourseName,Description,DepartmentId,SemesterId")] Course course)
        {
            if (ModelState.IsValid)
            {
                db.aCourses.Add(course);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DepartmentId = new SelectList(db.aDepartments, "DepartmentId", "Code", course.DepartmentId);
            ViewBag.SemesterId = new SelectList(db.aSemesters, "SemesterId", "SemesterName", course.SemesterId);
            return View(course);
        }

        // GET: /CourseEntry/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.aCourses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmentId = new SelectList(db.aDepartments, "DepartmentId", "Code", course.DepartmentId);
            ViewBag.SemesterId = new SelectList(db.aSemesters, "SemesterId", "SemesterName", course.SemesterId);
            return View(course);
        }

        // POST: /CourseEntry/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="CourseId,CourseCode,CourseCredit,CourseName,Description,DepartmentId,SemesterId")] Course course)
        {
            if (ModelState.IsValid)
            {
                db.Entry(course).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentId = new SelectList(db.aDepartments, "DepartmentId", "Code", course.DepartmentId);
            ViewBag.SemesterId = new SelectList(db.aSemesters, "SemesterId", "SemesterName", course.SemesterId);
            return View(course);
        }

        // GET: /CourseEntry/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.aCourses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // POST: /CourseEntry/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Course course = db.aCourses.Find(id);
            db.aCourses.Remove(course);
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
            var result = db.aCourses.Count(d => d.CourseCode == coursecode) == 0;
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Check_Coursname(string coursename)
        {
            var result = db.aCourses.Count(d => d.CourseName == coursename) == 0;
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}
