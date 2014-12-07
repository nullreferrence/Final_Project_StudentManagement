using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Dropdowntest.Models;

namespace Dropdowntest.Controllers
{
    public class CourseAssignController : Controller
    {
        private DropdownDBSet db = new DropdownDBSet();

        // GET: /CourseAssign/
        public ActionResult Index()
        {
            var courseassigns = db.CourseAssigns.Include(c => c.Courses).Include(c => c.Departments).Include(c => c.Teachers);
            return View(courseassigns.ToList());
        }

        // GET: /CourseAssign/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseAssign courseassign = db.CourseAssigns.Find(id);
            if (courseassign == null)
            {
                return HttpNotFound();
            }
            return View(courseassign);
        }

        // GET: /CourseAssign/Create
        public ActionResult Create()
        {
            ViewBag.CourseID = new SelectList(db.CoursesDbset, "CourseID", "CourseCredit");
            ViewBag.DepartmentID = new SelectList(db.DepartmentsDbset, "DepartmentID", "DepartmentCode");
            ViewBag.TeacherID = new SelectList(db.TeachersDcset, "TeacherID", "TeacherName");
            return View();
        }

        // POST: /CourseAssign/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="CourseAssignID,DepartmentID,CourseID,TeacherID")] CourseAssign courseassign)
        {
            if (ModelState.IsValid)
            {
                db.CourseAssigns.Add(courseassign);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CourseID = new SelectList(db.CoursesDbset, "CourseID", "CourseCredit", courseassign.CourseID);
            ViewBag.DepartmentID = new SelectList(db.DepartmentsDbset, "DepartmentID", "DepartmentCode", courseassign.DepartmentID);
            ViewBag.TeacherID = new SelectList(db.TeachersDcset, "TeacherID", "TeacherName", courseassign.TeacherID);
            return View(courseassign);
        }

        // GET: /CourseAssign/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseAssign courseassign = db.CourseAssigns.Find(id);
            if (courseassign == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseID = new SelectList(db.CoursesDbset, "CourseID", "CourseCredit", courseassign.CourseID);
            ViewBag.DepartmentID = new SelectList(db.DepartmentsDbset, "DepartmentID", "DepartmentCode", courseassign.DepartmentID);
            ViewBag.TeacherID = new SelectList(db.TeachersDcset, "TeacherID", "TeacherName", courseassign.TeacherID);
            return View(courseassign);
        }

        // POST: /CourseAssign/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="CourseAssignID,DepartmentID,CourseID,TeacherID")] CourseAssign courseassign)
        {
            if (ModelState.IsValid)
            {
                db.Entry(courseassign).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseID = new SelectList(db.CoursesDbset, "CourseID", "CourseCredit", courseassign.CourseID);
            ViewBag.DepartmentID = new SelectList(db.DepartmentsDbset, "DepartmentID", "DepartmentCode", courseassign.DepartmentID);
            ViewBag.TeacherID = new SelectList(db.TeachersDcset, "TeacherID", "TeacherName", courseassign.TeacherID);
            return View(courseassign);
        }

        // GET: /CourseAssign/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseAssign courseassign = db.CourseAssigns.Find(id);
            if (courseassign == null)
            {
                return HttpNotFound();
            }
            return View(courseassign);
        }

        // POST: /CourseAssign/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CourseAssign courseassign = db.CourseAssigns.Find(id);
            db.CourseAssigns.Remove(courseassign);
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

        public ActionResult GetCourseInfo(int depID)
        {
            var courseInfo = db.DepartmentsDbset.Where(x => x.DepartmentID == depID).Single();
            return Json(courseInfo, JsonRequestBehavior.AllowGet);
        }

        //public JsonResult GetStudentsByDepartmentId(int departmentId)
        //{
        //    var studentList = students.Where(a => a.DepartmentId == departmentId).ToList();
        //    return Json(studentList, JsonRequestBehavior.AllowGet);

        //}

        public JsonResult GetCoursebyDepartmentId(int depID)
        {
            var course = db.CoursesDbset.Where(c => c.DepartmnetID == depID).ToList();
            return Json(course, JsonRequestBehavior.AllowGet);
        }
    }
}
