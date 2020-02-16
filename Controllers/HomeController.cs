using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SeatingChart.Models;
using System.Configuration;
using System.Windows;
using System.Windows.Forms;
using System.Data.SqlClient;    

namespace SeatingChart.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Employee
        public ActionResult Index()
        {
            return View(db.BreakModels.ToList());
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


        public ActionResult NotAuthorized()
        {
            return View();
        }
    }
}