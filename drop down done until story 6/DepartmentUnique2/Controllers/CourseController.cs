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
    public class CourseController : Controller
    {
        private TestDBcontext db = new TestDBcontext();

        // GET: /Course/
        public ActionResult Index(int? departmentId)
        {
            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "Code");
            if (departmentId !=null)
            {
                return
                    View(db.CourseDbSet.Include(s => s.Departments).Where(s => s.Departments.DepartmentId == departmentId));
            }
            else
            {
                return View(db.CourseDbSet.Include(s => s.Departments));
            }
            //var coursedbset = db.CourseDbSet.Include(c => c.Departments).Include(c => c.Semisters);
            //return View(coursedbset.ToList());
        }

        public PartialViewResult FilteredCourse(int? depId)
        {
            if (depId != null)
            {
                var model = db.CourseDbSet.Include(s => s.Departments).Where(s => s.Departments.DepartmentId == depId);
                return PartialView("~/Views/Shared/_FilteredCourse.cshtml", model);
            }
            else
            {
                return PartialView("~/Views/Shared/_FilteredCourse.cshtml", db.CourseDbSet.Include(s => s.Departments));
            } 
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
            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "Name");
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

            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "Name", course.DepartmentId);
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
            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "Name", course.DepartmentId);
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
            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "Name", course.DepartmentId);
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

        public JsonResult Check_CourseCode(string coursecode)
        {
            var Ccode = db.CourseDbSet.Count(c => c.CourseCode == coursecode) == 0;
            return Json(Ccode, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Check_CourseName(string coursename)
        {
            var Cname = db.CourseDbSet.Count(n => n.CourseName == coursename) == 0;
            return Json(Cname, JsonRequestBehavior.AllowGet);
        }
    }
}
