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
    public class EnrolmentController : Controller
    {
        private RegDbContext db = new RegDbContext();

        // GET: /Enrolment/
        public ActionResult Index()
        {
            var enrollcourses = db.EnrollCourses.Include(e => e.Course);
            return View(enrollcourses.ToList());
        }
        

        // GET: /Enrolment/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnrollCourse enrollcourse = db.EnrollCourses.Find(id);
            if (enrollcourse == null)
            {
                return HttpNotFound();
            }
            return View(enrollcourse);
        }

        // GET: /Enrolment/Create
        public ActionResult Create()
        {
            ViewBag.CourseID = new SelectList(db.CourseDbSet, "CourseID", "CourseCode");
            return View();
        }

        // POST: /Enrolment/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="EnrollCourseId,CourseID,Date")] EnrollCourse enrollcourse)
        {
            if (ModelState.IsValid)
            {
                db.EnrollCourses.Add(enrollcourse);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CourseID = new SelectList(db.CourseDbSet, "CourseID", "CourseCode", enrollcourse.CourseID);
            return View(enrollcourse);
        }
        public ActionResult StudentPartial()
        {
            var enrollcourses = db.EnrollCourses.Include(e => e.Course);
            return PartialView("~/Views/Shared/_StudentPartial.cshtml", db.StudentDbSet.Include(s => s.StudentID));
        }

        // GET: /Enrolment/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnrollCourse enrollcourse = db.EnrollCourses.Find(id);
            if (enrollcourse == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseID = new SelectList(db.CourseDbSet, "CourseID", "CourseCode", enrollcourse.CourseID);
            return View(enrollcourse);
        }

        // POST: /Enrolment/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="EnrollCourseId,CourseID,Date")] EnrollCourse enrollcourse)
        {
            if (ModelState.IsValid)
            {
                db.Entry(enrollcourse).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseID = new SelectList(db.CourseDbSet, "CourseID", "CourseCode", enrollcourse.CourseID);
            return View(enrollcourse);
        }

        // GET: /Enrolment/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnrollCourse enrollcourse = db.EnrollCourses.Find(id);
            if (enrollcourse == null)
            {
                return HttpNotFound();
            }
            return View(enrollcourse);
        }

        // POST: /Enrolment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EnrollCourse enrollcourse = db.EnrollCourses.Find(id);
            db.EnrollCourses.Remove(enrollcourse);
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
