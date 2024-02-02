using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FolioProject.Models;

namespace FolioProject.Controllers
{
    public class AppointmentModels2Controller : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AppointmentModels2
        public ActionResult Index()
        {
            var appointmentModels2 = db.AppointmentModels2.Include(a => a.MedicImage);
            return View(appointmentModels2.ToList());
        }

        // GET: AppointmentModels2/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AppointmentModels2 appointmentModels2 = db.AppointmentModels2.Find(id);
            if (appointmentModels2 == null)
            {
                return HttpNotFound();
            }
            return View(appointmentModels2);
        }

        // GET: AppointmentModels2/Create
        public ActionResult Create()
        {
            ViewBag.MedicImageId = new SelectList(db.MedicImages, "Id", "Name");
            return View();
        }

        // POST: AppointmentModels2/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,MedicImageId,AppointmentTime,Description")] AppointmentModels2 appointmentModels2)
        {
            if (ModelState.IsValid)
            {
                db.AppointmentModels2.Add(appointmentModels2);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MedicImageId = new SelectList(db.MedicImages, "Id", "Name", appointmentModels2.MedicImageId);
            return View(appointmentModels2);
        }

        // GET: AppointmentModels2/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AppointmentModels2 appointmentModels2 = db.AppointmentModels2.Find(id);
            if (appointmentModels2 == null)
            {
                return HttpNotFound();
            }
            ViewBag.MedicImageId = new SelectList(db.MedicImages, "Id", "Name", appointmentModels2.MedicImageId);
            return View(appointmentModels2);
        }

        // POST: AppointmentModels2/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,MedicImageId,AppointmentTime,Description")] AppointmentModels2 appointmentModels2)
        {
            if (ModelState.IsValid)
            {
                db.Entry(appointmentModels2).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MedicImageId = new SelectList(db.MedicImages, "Id", "Name", appointmentModels2.MedicImageId);
            return View(appointmentModels2);
        }

        // GET: AppointmentModels2/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AppointmentModels2 appointmentModels2 = db.AppointmentModels2.Find(id);
            if (appointmentModels2 == null)
            {
                return HttpNotFound();
            }
            return View(appointmentModels2);
        }

        // POST: AppointmentModels2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AppointmentModels2 appointmentModels2 = db.AppointmentModels2.Find(id);
            db.AppointmentModels2.Remove(appointmentModels2);
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
