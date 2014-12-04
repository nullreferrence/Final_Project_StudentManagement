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
    public class AllocateClassRoomController : Controller
    {
        private RegDbContext db = new RegDbContext();

        // GET: /AllocateClassRoom/
        public ActionResult Index()
        {
            var allocateclassrooms = db.AllocateClassRooms.Include(a => a.Course).Include(a => a.Days).Include(a => a.Rooms);
            return View(allocateclassrooms.ToList());
        }

        // GET: /AllocateClassRoom/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AllocateClassRoom allocateclassroom = db.AllocateClassRooms.Find(id);
            if (allocateclassroom == null)
            {
                return HttpNotFound();
            }
            return View(allocateclassroom);
        }

        // GET: /AllocateClassRoom/Create
        public ActionResult Create()
        {
            ViewBag.CourseID = new SelectList(db.CourseDbSet, "CourseID", "CourseCode");
            ViewBag.DaysId = new SelectList(db.DayDbSet, "DaysId", "DaysName");
            ViewBag.RoomsId = new SelectList(db.RoomseDbSet, "RoomsId", "RoomsName");
            return View();
        }

        // POST: /AllocateClassRoom/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="AllocateClassRoomId,CourseID,RoomsId,DaysId")] AllocateClassRoom allocateclassroom)
        {
            if (ModelState.IsValid)
            {
                db.AllocateClassRooms.Add(allocateclassroom);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CourseID = new SelectList(db.CourseDbSet, "CourseID", "CourseCode", allocateclassroom.CourseID);
            ViewBag.DaysId = new SelectList(db.DayDbSet, "DaysId", "DaysName", allocateclassroom.DaysId);
            ViewBag.RoomsId = new SelectList(db.RoomseDbSet, "RoomsId", "RoomsName", allocateclassroom.RoomsId);
            return View(allocateclassroom);
        }

        // GET: /AllocateClassRoom/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AllocateClassRoom allocateclassroom = db.AllocateClassRooms.Find(id);
            if (allocateclassroom == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseID = new SelectList(db.CourseDbSet, "CourseID", "CourseCode", allocateclassroom.CourseID);
            ViewBag.DaysId = new SelectList(db.DayDbSet, "DaysId", "DaysName", allocateclassroom.DaysId);
            ViewBag.RoomsId = new SelectList(db.RoomseDbSet, "RoomsId", "RoomsName", allocateclassroom.RoomsId);
            return View(allocateclassroom);
        }

        // POST: /AllocateClassRoom/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="AllocateClassRoomId,CourseID,RoomsId,DaysId")] AllocateClassRoom allocateclassroom)
        {
            if (ModelState.IsValid)
            {
                db.Entry(allocateclassroom).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseID = new SelectList(db.CourseDbSet, "CourseID", "CourseCode", allocateclassroom.CourseID);
            ViewBag.DaysId = new SelectList(db.DayDbSet, "DaysId", "DaysName", allocateclassroom.DaysId);
            ViewBag.RoomsId = new SelectList(db.RoomseDbSet, "RoomsId", "RoomsName", allocateclassroom.RoomsId);
            return View(allocateclassroom);
        }

        // GET: /AllocateClassRoom/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AllocateClassRoom allocateclassroom = db.AllocateClassRooms.Find(id);
            if (allocateclassroom == null)
            {
                return HttpNotFound();
            }
            return View(allocateclassroom);
        }

        // POST: /AllocateClassRoom/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AllocateClassRoom allocateclassroom = db.AllocateClassRooms.Find(id);
            db.AllocateClassRooms.Remove(allocateclassroom);
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
