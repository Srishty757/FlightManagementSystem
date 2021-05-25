using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FlightManagementSystem.Models;

namespace FlightManagementSystem.Controllers
{
    public class AdminController : Controller
    {
        ContextCS c = new ContextCS();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AdminLogin()
        {
            if (Session["u"] != null)
            {
                return RedirectToAction("Dashboard");
            }
            else
            {
                return View();
            }
            
        }
        [HttpPost]
        public ActionResult AdminLogin(AdminLogin l)
        {
            var x = c.AdminLogins.Where(a => a.Adminname == l.Adminname && a.Password == l.Password).FirstOrDefault();
            if(x!=null)
            {
                Session["u"] = l.Adminname;
                return RedirectToAction("Dashboard");
            }
            else
            {
                ViewBag.m = "Wrong id or Password";
            }
            return View();
        }
        public ActionResult Dashboard()
        {
            return View();
        }

    }
}