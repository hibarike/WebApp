using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;

namespace WebApplication.Controllers
{
    public class HomeController : Controller

    {

        // создаем контекст данных
        PlanFactContext db = new PlanFactContext();

        public ActionResult Index()
        {
            // получаем из бд все объекты Book
            //IEnumerable<City> cities = db.Cities;
            // передаем все объекты в динамическое свойство Books в ViewBag
           // ViewBag.Cities = cities;
            // возвращаем представление
            return View();
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(City city)
        {
            bool check = true;
            var list = db.Cities.ToList();
            foreach(var b in list)
            if (b.Name == city.Name)
            {
                    check = false;
                    break;
            }
            if(check)
            {
                db.Cities.Add(city);
                db.SaveChanges();

                return RedirectToAction("ListOfCities");
            }
            return RedirectToAction("ListOfCities");
        }
        //отображение городов
        public ActionResult ListOfCities()
        {
            // получаем из бд все объекты Book
            IEnumerable<City> cities = db.Cities;
            // передаем все объекты в динамическое свойство Books в ViewBag
            ViewBag.Cities = cities;
            // возвращаем представление
            return View();
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            City b = db.Cities.Find(id);
            if (b == null)
            {
                return HttpNotFound();
            }
            return View(b);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            City b = db.Cities.Find(id);
            if (b == null)
            {
                return HttpNotFound();
            }
            db.Cities.Remove(b);
            db.SaveChanges();
            return RedirectToAction("ListOfCities");
        }
    }
}