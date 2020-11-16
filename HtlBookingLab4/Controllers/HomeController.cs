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

        [HttpPost]
        public ActionResult Create(Room room)
        {
            //Добавляем книгу в таблицу
            db.Rooms.Add(room);
            db.SaveChanges();
            // перенаправляем на главную страницу
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            // Находим в бд книгу
            Room room = db.Rooms.Find(id);
            if (room != null)
            {
                // Создаем список авторов книг для передачи в представление
                SelectList roomClasses = new SelectList(db.RoomClasses, "Id", "Name", room.RoomClassId);
                ViewBag.RoomClasses = roomClasses;
                return View(room);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Edit(Room room)
        {
            db.Entry(room).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            // Находим в бд книгу
            Room room = db.Rooms.Find(id);
            if (room != null)
            {
                db.Rooms.Remove(room);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
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