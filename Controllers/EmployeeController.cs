using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SeatingChart.Models;

namespace SeatingChart.Controllers
{
    public class EmployeeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Employee
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return View(db.EmployeeModels.ToList());
            }
            else
            {
                return View("NotAuthorized");
            }
        }

        // GET: Employee/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeModels employeeModels = db.EmployeeModels.Find(id);
            if (employeeModels == null)
            {
                return HttpNotFound();
            }
            return View(employeeModels);
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            if (User.Identity.IsAuthenticated)
            {
                return View();
            }
            else
            {
                return View("NotAuthorized");
            }
        }

        // POST: Employee/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,DisplayName,NotActive,Force")] EmployeeModels employeeModels)
        {
            if (ModelState.IsValid)
            {
                db.EmployeeModels.Add(employeeModels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employeeModels);
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int? id)
        {
            if (User.Identity.IsAuthenticated == false)
            {
                return View("NotAuthorized");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeModels employeeModels = db.EmployeeModels.Find(id);
            if (employeeModels == null)
            {
                return HttpNotFound();
            }
            return View(employeeModels);
        }

        // POST: Employee/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,DisplayName,NotActive,Force")] EmployeeModels employeeModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employeeModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employeeModels);
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int? id)
        {
            if (User.Identity.IsAuthenticated == false)
            {
                return View("NotAuthorized");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            EmployeeModels employeeModels = db.EmployeeModels.Find(id);
            if (employeeModels == null)
            {
                return HttpNotFound();
            }
            return View(employeeModels);
        }

        // POST: Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmployeeModels employeeModels = db.EmployeeModels.Find(id);
            employeeModels.NotActive = true;
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

        public ActionResult Register()
        {
            if (User.Identity.IsAuthenticated)
            {
                return View();
            }
            else
            {
                return View("NotAuthorized");
            }
        }

        public ActionResult NotAuthorized()
        {
            return View();
        }
    }
}
