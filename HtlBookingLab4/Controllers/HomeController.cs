using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using HtlBookingLab4.Models;

namespace HtlBookingLab4.Controllers
{
    public class HomeController:Controller
    {
        RmContext db = new RmContext();
        public ActionResult Index()
        {
            var rooms = db.Rooms.Include(r => r.RoomClass);
            return View(rooms.ToList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            // Формируем список авторов для передачи в представление
            SelectList roomClasses = new SelectList(db.RoomClasses, "Id", "Name");
            ViewBag.RoomClasses = roomClasses;
            return View();
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