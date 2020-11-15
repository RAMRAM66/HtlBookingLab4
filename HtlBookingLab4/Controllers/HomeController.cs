using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using HtlBookingLab4.Models;

namespace HtlBookingLab4.Controllers
{
    public class HomeController : Controller
    {
        RmContext db = new RmContext();
        public ActionResult Index()
        {
            var rooms = db.Rooms.Include(r => r.RoomClass);
            return View(rooms.ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}