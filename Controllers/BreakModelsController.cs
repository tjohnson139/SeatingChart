using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SeatingChart.Models;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace SeatingChart.Controllers
{
    public class BreakModelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: BreakModels
        public ActionResult Index()
        {
            var breakModels = db.BreakModels.Include(b => b.EmployeeModels);
            return View(breakModels.ToList());
        }

        // GET: BreakModels/Details/5
        public ActionResult Details(int? id)
        {
            BreakModels breakModels = db.BreakModels.Find(id);
            return View(breakModels);
        }

        // GET: BreakModels/Create
        public ActionResult Create()
        {
            ViewBag.Employee = new SelectList(db.EmployeeModels, "DisplayName");
            return View();
        }

        // POST: BreakModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Employee,TimeEntered,TimeCleared")] BreakModels breakModels)
        {
            if (ModelState.IsValid)
            {
                db.BreakModels.Add(breakModels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Employee = new SelectList(db.EmployeeModels, "Id", "DisplayName", breakModels.Employee);
            return View(breakModels);
        }

        // GET: BreakModels/Edit/5
        public ActionResult Edit(int? id)
        {
            BreakModels breakModels = db.BreakModels.Find(id);
            ViewBag.Employee = new SelectList(db.EmployeeModels, "Id", "DisplayName", breakModels.Employee);
            return View(breakModels);
        }

        // POST: BreakModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Employee,TimeEntered,TimeCleared")] BreakModels breakModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(breakModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Employee = new SelectList(db.EmployeeModels, "Id", "DisplayName", breakModels.Employee);
            return View(breakModels);
        }

        // GET: BreakModels/Delete/5
        public ActionResult Delete(int? id)
        {
            BreakModels breakModels = db.BreakModels.Find(id);
            return View(breakModels);
        }

        // POST: BreakModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BreakModels breakModels = db.BreakModels.Find(id);
            db.BreakModels.Remove(breakModels);
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
