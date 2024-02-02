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
    public class MedicImagesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: MedicImages
        public ActionResult Index()
        {
            return View(db.MedicImages.ToList());
        }

        // GET: MedicImages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MedicImage medicImage = db.MedicImages.Find(id);
            if (medicImage == null)
            {
                return HttpNotFound();
            }
            return View(medicImage);
        }

        
        // GET: MedicImages/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: MedicImages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Location")] MedicImage medicImage)
        {
            if (ModelState.IsValid)
            {
                db.MedicImages.Add(medicImage);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(medicImage);
        }

        // GET: MedicImages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MedicImage medicImage = db.MedicImages.Find(id);
            if (medicImage == null)
            {
                return HttpNotFound();
            }
            return View(medicImage);
        }

        // POST: MedicImages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Location")] MedicImage medicImage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(medicImage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(medicImage);
        }

        // GET: MedicImages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MedicImage medicImage = db.MedicImages.Find(id);
            if (medicImage == null)
            {
                return HttpNotFound();
            }
            return View(medicImage);
        }

        // POST: MedicImages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MedicImage medicImage = db.MedicImages.Find(id);
            db.MedicImages.Remove(medicImage);
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
