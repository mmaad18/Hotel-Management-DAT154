using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotelManagement.DAL;
using HotelManagement.Entities.Persons.Guests;

namespace HotelManagement.Booking.Controllers
{
    public class LoginController : Controller
    {
        private readonly HotelManagementContext db = new HotelManagementContext();

        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        // GET: Login
        public ActionResult LogOut()
        {
            if (Request.Cookies["Auth"] != null)
                Response.Cookies["Auth"].Expires = DateTime.Now.AddDays(-1);
            return RedirectToAction("Index", "Home");
            ;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Authenticate([Bind(Include = "Id,Username,PasswordHash")] Guest guest)
        {
            var databaseGuest = db.Guests.ToList()
                .First(x => x.Username.ToLower() == guest.Username.ToLower() &&
                            x.PasswordHash.ToLower() == guest.PasswordHash.ToLower());

            if (databaseGuest == null)
                return View("BadLoginView");
            if (Request.Cookies["Auth"] == null)
            {
                Response.Cookies["Auth"].Value = "1";
                Response.Cookies["GuestId"].Value = databaseGuest.Id.ToString();
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Auth([Bind(Include = "Username,PasswordHash")] Guest guest)
        {
            var myCookie = new HttpCookie("MyTestCookie");
            var now = DateTime.Now;

            // Set the cookie value.
            myCookie.Value = now.ToString();
            // Set the cookie expiration date.
            myCookie.Expires = now.AddYears(50); // For a cookie to effectively never expire

            // Add the cookie.
            Response.Cookies.Add(myCookie);

            Response.Write("<p> The cookie has been written.");

            if (ModelState.IsValid)
            {
                //return RedirectToAction("../Home/About");
            }

            //return View(guest);

            return RedirectToAction("ReadCookie");
        }

        public ActionResult ReadCookie([Bind(Include = "Username,PasswordHash")] Guest guest)
        {
            var myCookie = Request.Cookies["MyTestCookie"];

            // Read the cookie information and display it.
            if (myCookie != null)
                Response.Write("<p>" + myCookie.Name + "<p>" + myCookie.Value);
            else
                Response.Write("not found");

            return RedirectToAction("../Home/About");
        }
    }
}