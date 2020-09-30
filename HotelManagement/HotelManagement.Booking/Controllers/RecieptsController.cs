using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HotelManagement.DAL;
using HotelManagement.Entities.Bills;
using HotelManagement.Entities.Reciepts;
using HotelManagement.Entities.Rooms;
using HotelManagement.Entities.Rooms.States;

namespace HotelManagement.Booking.Controllers
{
    public class RecieptsController : Controller
    {
        private HotelManagementContext db = new HotelManagementContext();
        
        // GET: Reciepts
        public ActionResult Index()
        {
            int id;
            if (Request.Cookies["Auth"] != null && Request.Cookies["GuestId"] != null)
            {
                id = int.Parse(Request.Cookies["GuestId"].Value);
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
            var rec = db.Reciepts.ToList().Where(x => x.GuestId == id);
            return View(rec.ToList());
        }

        // GET: Reciepts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reciept reciept = db.Reciepts.Find(id);
            Room bills = db.Rooms.Find(reciept.RoomId);
            ViewBag.Room = bills;
            if (reciept == null)
            {
                return HttpNotFound();
            }
            return View(reciept);
        }

        // GET: Reciepts/Create
        public ActionResult Create()
        {
            List<SelectListItem> RoomType = new List<SelectListItem>();

            List<SelectListItem> RoomQuality = new List<SelectListItem>();

            if (db.Rooms.ToList().Any(x => x.Type == "Single Room" && x.State.GetType() == typeof(AvailableState))) ;
            {
                RoomType.Add(new SelectListItem {Text = "Single Room", Value = "Single Room"});

            }
            if (db.Rooms.ToList().Any(x => x.Type == "Double Room" && x.State.GetType() == typeof(AvailableState))) ;
            {
                RoomType.Add(new SelectListItem { Text = "Double Room", Value = "Double Room" });

            }
            if (db.Rooms.ToList().Any(x => x.Quality == "Standard" && x.State.GetType() == typeof(AvailableState))) ;
            {
                RoomQuality.Add(new SelectListItem { Text = "Standard", Value = "Standard" });

            }
            if (db.Rooms.ToList().Any(x => x.Type == "Vip" && x.State.GetType() == typeof(AvailableState))) ;
            {
                RoomQuality.Add(new SelectListItem { Text = "Vip", Value = "Vip" });
            }


            ViewBag.RoomTypes = RoomType;
            ViewBag.RoomQualities = RoomQuality;


            ViewBag.GuestId = new SelectList(db.Guests, "Id", "FirstName");
            return View();
        }

        // POST: Reciepts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StayedFromDate,StayedToDate,RoomTypes,RoomQualities")] Reciept reciept)
        {
            if (ModelState.IsValid)
            {
                string RoomQuality = Request.Form["RoomQualities"];
                string RoomType = Request.Form["RoomTypes"];

                if (Request.Cookies["Auth"] != null && Request.Cookies["GuestId"] != null)
                {
                    reciept.GuestId = int.Parse(Request.Cookies["GuestId"].Value);
                    reciept.RoomQuality = RoomQuality;
                    reciept.RoomType = RoomType;

                }
                else
                {
                    return RedirectToAction("Login", "Login");
                }
                reciept.GuestName= db.Guests.Find(reciept.GuestId).FullName;

                db.Reciepts.Add(reciept);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            return View("BadRecieptView");
        }

        // GET: Reciepts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reciept reciept = db.Reciepts.Find(id);
            if (reciept == null)
            {
                return HttpNotFound();
            }
            ViewBag.GuestId = new SelectList(db.Guests, "Id", "FirstName", reciept.GuestId);
            return View(reciept);
        }

        // POST: Reciepts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,StayedFromDate,StayedToDate,SettledDate,StateString,GuestId")] Reciept reciept)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reciept).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GuestId = new SelectList(db.Guests, "Id", "FirstName", reciept.GuestId);
            return View(reciept);
        }

        // GET: Reciepts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reciept reciept = db.Reciepts.Find(id);
            if (reciept == null)
            {
                return HttpNotFound();
            }
            return View(reciept);
        }

        // POST: Reciepts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Reciept reciept = db.Reciepts.Find(id);
            db.Reciepts.Remove(reciept);
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
