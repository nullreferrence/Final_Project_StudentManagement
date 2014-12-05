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
    public class AllocateroomController : Controller
    {
        private ProjectDbContext db = new ProjectDbContext();

        // GET: /Allocateroom/
        public ActionResult Index()
        {
            var allocate_class_room = db.Allocate_Class_Room.Include(a => a.ACourse).Include(a => a.ARoom);
            return View(allocate_class_room.ToList());
        }

        // GET: /Allocateroom/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Allocate_Class_Room allocate_class_room = db.Allocate_Class_Room.Find(id);
            if (allocate_class_room == null)
            {
                return HttpNotFound();
            }
            return View(allocate_class_room);
        }

        // GET: /Allocateroom/Create
        public ActionResult Create()
        {
            ViewBag.CourseId = new SelectList(db.aCourses, "CourseId", "CourseCode");
            ViewBag.RoomId = new SelectList(db.Rooms, "RoomId", "RoomNo");
            return View();
        }

        // POST: /Allocateroom/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Allocate_Class_RoomID,CourseId,RoomId,Date,TimeFrom,TimeTo")] Allocate_Class_Room allocate_class_room)
        {
            if (ModelState.IsValid)
            {
                db.Allocate_Class_Room.Add(allocate_class_room);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CourseId = new SelectList(db.aCourses, "CourseId", "CourseCode", allocate_class_room.CourseId);
            ViewBag.RoomId = new SelectList(db.Rooms, "RoomId", "RoomNo", allocate_class_room.RoomId);
            return View(allocate_class_room);
        }

        // GET: /Allocateroom/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Allocate_Class_Room allocate_class_room = db.Allocate_Class_Room.Find(id);
            if (allocate_class_room == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseId = new SelectList(db.aCourses, "CourseId", "CourseCode", allocate_class_room.CourseId);
            ViewBag.RoomId = new SelectList(db.Rooms, "RoomId", "RoomNo", allocate_class_room.RoomId);
            return View(allocate_class_room);
        }

        // POST: /Allocateroom/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Allocate_Class_RoomID,CourseId,RoomId,Date,TimeFrom,TimeTo")] Allocate_Class_Room allocate_class_room)
        {
            if (ModelState.IsValid)
            {
                db.Entry(allocate_class_room).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseId = new SelectList(db.aCourses, "CourseId", "CourseCode", allocate_class_room.CourseId);
            ViewBag.RoomId = new SelectList(db.Rooms, "RoomId", "RoomNo", allocate_class_room.RoomId);
            return View(allocate_class_room);
        }

        // GET: /Allocateroom/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Allocate_Class_Room allocate_class_room = db.Allocate_Class_Room.Find(id);
            if (allocate_class_room == null)
            {
                return HttpNotFound();
            }
            return View(allocate_class_room);
        }

        // POST: /Allocateroom/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Allocate_Class_Room allocate_class_room = db.Allocate_Class_Room.Find(id);
            db.Allocate_Class_Room.Remove(allocate_class_room);
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
