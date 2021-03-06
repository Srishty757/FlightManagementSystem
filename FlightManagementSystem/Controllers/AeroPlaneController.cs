using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using FlightManagementSystem.Models;

namespace FlightManagementSystem.Controllers
{
    public class AeroPlaneController : Controller
    {
        private ContextCS db = new ContextCS();

        // GET: AeroPlane
        public ActionResult Index (string Sorting_Order, string Search_Data)
        {
            ViewBag.SortingName = String.IsNullOrEmpty(Sorting_Order) ? "Name_Description" : "";
            ViewBag.SortingPrice = Sorting_Order == "Seating_Capacity" ? "Price" : "Price";
            var flights = from flight in db.flightInfos select flight;
            {
                flights = flights.Where(flight => flight.FlightName.ToUpper().Contains(Search_Data.ToUpper()) 
                );
            }
            switch (Sorting_Order)
            {
                case "Name_Description":
                    flights = flights.OrderByDescending(flight => flight.FlightName);
                    break;
                case "Seating_Capacity":
                    flights = flights.OrderByDescending(flight => flight.SeatingCapacity);
                    break;
                case "Price":
                    flights = flights.OrderByDescending(flight => flight.Price);
                    break;
                default:
                    flights = flights.OrderByDescending(flight => flight.FlightName);
                    break;
            }
                    return View(db.flightInfos.ToList());
        }

        // GET: AeroPlane/Details/5
        public ActionResult Details(int? FlightId)
        {
            var data = db.flightInfos.Where(c => c.FlightId == FlightId).FirstOrDefault();
            return View(data);

        }
        
        
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FlightId,FlightName,SeatingCapacity,Price")] UserAccount.FlightInfo flightInfo)
        {
            if (ModelState.IsValid)
            {
                db.flightInfos.Add(flightInfo);
                db.SaveChanges();
                ViewBag.m = "Records Saved";
                return View();
            }

            return View(flightInfo);
        }

        [HttpGet]
        public ActionResult Edit(int? FlightId)
        {
            
            var data = db.flightInfos.Where(c => c.FlightId == FlightId).FirstOrDefault();
            return View(data);
           
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UserAccount.FlightInfo flightInfos)
        {
            var data = db.flightInfos.Where(c => c.FlightId == flightInfos.FlightId).FirstOrDefault();
            if (data != null)
            {
                data.FlightName = flightInfos.FlightName;
                data.SeatingCapacity = flightInfos.SeatingCapacity;
                data.Price = flightInfos.Price;
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        // GET: AeroPlane/Delete/5
        public ActionResult Delete(int? FlightId)
        {
            if (FlightId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserAccount.FlightInfo flightInfo = db.flightInfos.Find(FlightId);
            if (flightInfo == null)
            {
                return HttpNotFound();
            }
            return View(flightInfo);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(UserAccount.FlightInfo flightInfos)
        {
            var data = db.flightInfos.Where(c => c.FlightId == flightInfos.FlightId).FirstOrDefault();
            db.flightInfos.Remove(data);
            db.SaveChanges();
            ViewBag.Messsage = "Record Delete Successfully";
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
