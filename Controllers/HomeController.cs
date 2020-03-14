using System;
using System.Data;
using System.Linq;
using System.Web.Mvc;
using SeatingChart.Models;

namespace SeatingChart.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Employee
        // Sets up the information for the table on the main page
        public ActionResult Index()
        {
            var breaks = db.BreakModels.Include("BreakId")
                                .Include("Employee")
                                .Include("TimeEntered")
                                .Include("TimeCleared")
                                .Include("DisplayName")
                                .Select(a => new HomeIndexViewModels
                                {
                                    BreakId=a.BreakId,
                                    Employee = a.Employee,
                                    DisplayName = a.EmployeeModels.DisplayName,
                                    TimeEntered = a.TimeEntered,
                                    TimeCleared = a.TimeCleared.Value,
                                });

            ViewBag.EmployeeNames = db.EmployeeModels.Where(x => x.NotActive == false).ToList();
            return View(breaks);
        }

        //Adds employees to the break list from the dropdown on the index page
        [System.Web.Http.HttpPost]
        public ActionResult CreateData(BreakModels breakmodels)
        {
            try
            {
                breakmodels.TimeEntered = DateTime.Now;
                db.BreakModels.Add(breakmodels);
                db.SaveChanges();
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false });
            }
        }

        [HttpPost]
        public ActionResult DeleteBreak(int breakID)
        {
            try { 
            var oldBreakModel = db.BreakModels.Where(x => x.BreakId == breakID).FirstOrDefault();
            oldBreakModel.TimeCleared = DateTime.Now;

            return Json(db.SaveChanges() > 0, JsonRequestBehavior.AllowGet);
            }
            catch(Exception)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }
        

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Admin()
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

        public ActionResult Edit()
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

        public ActionResult Delete()
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


        // Returns the no authorization page
        public ActionResult NotAuthorized()
        {
            return View();
        }
    }
}