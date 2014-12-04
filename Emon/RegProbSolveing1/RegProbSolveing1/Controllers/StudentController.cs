using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RegProbSolveing1.Models;
using RegProbSolveing1.Models;

namespace RegProbSolveing1.Controllers
{
    public class StudentController : Controller
    {
        private RegDbContext db = new RegDbContext();

        // GET: /Student/
        public ActionResult Index()
        {
            var studentdbset = db.StudentDbSet.Include(s => s.Department);
            return View(studentdbset.ToList());
        }

        // GET: /Student/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.StudentDbSet.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }


        // GET: /Student/Create
        public ActionResult Create()
        {
            ViewBag.DepartmentID = new SelectList(db.DepartmentDbSet, "DepartmentID", "DeptCode");
            return View();
        }

        // POST: /Student/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="StudentID,RegNo,StudentName,Email,ContactNo,AdmissionDate,Address,DepartmentID")] Student student)
        {
            if (ModelState.IsValid)
            {
                int id =1;
               Department aDepartment=new Department();
               student.RegNo = ("reg No" + (++id)).SingleOrDefault().ToString();

                //if (aDepartment.DepartmentID==1)
                //{
                //    student.RegNo = ("reg No"+ id).LongCount().ToString();
                //}
                //else if (aDepartment.DepartmentID >1)
                //{
                //    student.RegNo = (aDepartment.DeptCode + id).LongCount().ToString();
                //}
                      
                

                db.StudentDbSet.Add(student);
                db.SaveChanges();
                return RedirectToAction("Create");
            }

            ViewBag.DepartmentID = new SelectList(db.DepartmentDbSet, "DepartmentID", "DeptCode", student.DepartmentID);
            ViewBag.DepartmentID = student.StudentName + "Your Reg No is" + student.RegNo;
            return View(student);
        }

        // GET: /Student/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.StudentDbSet.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmentID = new SelectList(db.DepartmentDbSet, "DepartmentID", "DeptCode", student.DepartmentID);
            return View(student);
        }

        // POST: /Student/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="StudentID,RegNo,StudentName,Email,ContactNo,AdmissionDate,Address,DepartmentID")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentID = new SelectList(db.DepartmentDbSet, "DepartmentID", "DeptCode", student.DepartmentID);
            return View(student);
        }

        // GET: /Student/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.StudentDbSet.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: /Student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Student student = db.StudentDbSet.Find(id);
            db.StudentDbSet.Remove(student);
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
