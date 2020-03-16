using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SeatingChart.Models;

namespace SeatingChart
{
    public class DthModelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: DthModels
        public ActionResult Index()
        {
            var dthModels = db.DthModels.Include(d => d.EmployeeModels);
            return View(dthModels.ToList());
        }

        // GET: DthModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DthModels dthModels = db.DthModels.Find(id);
            if (dthModels == null)
            {
                return HttpNotFound();
            }
            return View(dthModels);
        }

        // GET: DthModels/Create
        public ActionResult Create()
        {
            ViewBag.DthEmployee = new SelectList(db.EmployeeModels, "Id", "FirstName");
            return View();
        }

        // POST: DthModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DthId,DthEmployee,DthTimeEntered,DthTimeCleared")] DthModels dthModels)
        {
            if (ModelState.IsValid)
            {
                db.DthModels.Add(dthModels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DthEmployee = new SelectList(db.EmployeeModels, "Id", "FirstName", dthModels.DthEmployee);
            return View(dthModels);
        }

        // GET: DthModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DthModels dthModels = db.DthModels.Find(id);
            if (dthModels == null)
            {
                return HttpNotFound();
            }
            ViewBag.DthEmployee = new SelectList(db.EmployeeModels, "Id", "FirstName", dthModels.DthEmployee);
            return View(dthModels);
        }

        // POST: DthModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DthId,DthEmployee,DthTimeEntered,DthTimeCleared")] DthModels dthModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dthModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DthEmployee = new SelectList(db.EmployeeModels, "Id", "FirstName", dthModels.DthEmployee);
            return View(dthModels);
        }

        // GET: DthModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DthModels dthModels = db.DthModels.Find(id);
            if (dthModels == null)
            {
                return HttpNotFound();
            }
            return View(dthModels);
        }

        // POST: DthModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DthModels dthModels = db.DthModels.Find(id);
            db.DthModels.Remove(dthModels);
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
