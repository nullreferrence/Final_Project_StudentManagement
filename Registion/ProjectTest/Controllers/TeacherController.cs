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
    public class TeacherController : Controller
    {
        private ProjectDbContext db = new ProjectDbContext();

        // GET: /Teacher/
        public ActionResult Index()
        {
            var ateachers = db.ATeachers.Include(t => t.ADepartment).Include(t => t.ADesignation);
            return View(ateachers.ToList());
        }

        // GET: /Teacher/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teacher teacher = db.ATeachers.Find(id);
            if (teacher == null)
            {
                return HttpNotFound();
            }
            return View(teacher);
        }

        // GET: /Teacher/Create
        public ActionResult Create()
        {
            ViewBag.DepartmentId = new SelectList(db.aDepartments, "DepartmentId", "Name");
            ViewBag.DesignationId = new SelectList(db.aDesignations, "DesignationId", "TeacherDesignation");
            return View();
        }

        // POST: /Teacher/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="TeacherId,TeacherName,TeacherAddress,TeacherEmail,DesignationId,DepartmentId,TeacherCredit")] Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                db.ATeachers.Add(teacher);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DepartmentId = new SelectList(db.aDepartments, "DepartmentId", "Name", teacher.DepartmentId);
            ViewBag.DesignationId = new SelectList(db.aDesignations, "DesignationId", "TeacherDesignation", teacher.DesignationId);
            return View(teacher);
        }

        // GET: /Teacher/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teacher teacher = db.ATeachers.Find(id);
            if (teacher == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmentId = new SelectList(db.aDepartments, "DepartmentId", "Name", teacher.DepartmentId);
            ViewBag.DesignationId = new SelectList(db.aDesignations, "DesignationId", "TeacherDesignation", teacher.DesignationId);
            return View(teacher);
        }

        // POST: /Teacher/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="TeacherId,TeacherName,TeacherAddress,TeacherEmail,DesignationId,DepartmentId,TeacherCredit")] Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                db.Entry(teacher).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentId = new SelectList(db.aDepartments, "DepartmentId", "Name", teacher.DepartmentId);
            ViewBag.DesignationId = new SelectList(db.aDesignations, "DesignationId", "TeacherDesignation", teacher.DesignationId);
            return View(teacher);
        }

        // GET: /Teacher/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teacher teacher = db.ATeachers.Find(id);
            if (teacher == null)
            {
                return HttpNotFound();
            }
            return View(teacher);
        }

        // POST: /Teacher/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Teacher teacher = db.ATeachers.Find(id);
            db.ATeachers.Remove(teacher);
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

        public JsonResult Check_TeacherEmail(string teacheremail)
        {
            var result = db.ATeachers.Count(d => d.TeacherEmail == teacheremail) == 0;
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        }
    }

