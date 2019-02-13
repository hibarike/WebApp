using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;

namespace WebApplication.Controllers
{
    public class ActualNumberOfShipmentsController : Controller
    {
        private PlanFactContext db = new PlanFactContext();

        // GET: ActualNumberOfShipments
        public async Task<ActionResult> Index()
        {
            var actuals = db.Actuals.Include(a => a.ActualInMonthForThisWay).Include(a => a.ArrivalCity).Include(a => a.DepartureCity);
            return View(await actuals.ToListAsync());
        }

        // GET: ActualNumberOfShipments/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ActualNumberOfShipments actualNumberOfShipments = await db.Actuals.FindAsync(id);
            if (actualNumberOfShipments == null)
            {
                return HttpNotFound();
            }
            return View(actualNumberOfShipments);
        }

        // GET: ActualNumberOfShipments/Create
        public ActionResult Create()
        {
            ViewBag.ActualInMonthId = new SelectList(db.ActualInMonths, "Id", "InternalDays");
            ViewBag.ArrivalCityId = new SelectList(db.Cities, "Id", "Name");
            ViewBag.DepartureCityId = new SelectList(db.Cities, "Id", "Name");
            return View();
        }

        // POST: ActualNumberOfShipments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,DepartureCityId,ArrivalCityId,PlanedNumberOfShipments,ActualInMonthId")] ActualNumberOfShipments actualNumberOfShipments)
        {
            if (ModelState.IsValid)
            {
                db.Actuals.Add(actualNumberOfShipments);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ActualInMonthId = new SelectList(db.ActualInMonths, "Id", "InternalDays", actualNumberOfShipments.ActualInMonthId);
            ViewBag.ArrivalCityId = new SelectList(db.Cities, "Id", "Name", actualNumberOfShipments.ArrivalCityId);
            ViewBag.DepartureCityId = new SelectList(db.Cities, "Id", "Name", actualNumberOfShipments.DepartureCityId);
            return View(actualNumberOfShipments);
        }

        // GET: ActualNumberOfShipments/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ActualNumberOfShipments actualNumberOfShipments = await db.Actuals.FindAsync(id);
            if (actualNumberOfShipments == null)
            {
                return HttpNotFound();
            }
            ViewBag.ActualInMonthId = new SelectList(db.ActualInMonths, "Id", "InternalDays", actualNumberOfShipments.ActualInMonthId);
            ViewBag.ArrivalCityId = new SelectList(db.Cities, "Id", "Name", actualNumberOfShipments.ArrivalCityId);
            ViewBag.DepartureCityId = new SelectList(db.Cities, "Id", "Name", actualNumberOfShipments.DepartureCityId);
            return View(actualNumberOfShipments);
        }

        // POST: ActualNumberOfShipments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,DepartureCityId,ArrivalCityId,PlanedNumberOfShipments,ActualInMonthId")] ActualNumberOfShipments actualNumberOfShipments)
        {
            if (ModelState.IsValid)
            {
                db.Entry(actualNumberOfShipments).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ActualInMonthId = new SelectList(db.ActualInMonths, "Id", "InternalDays", actualNumberOfShipments.ActualInMonthId);
            ViewBag.ArrivalCityId = new SelectList(db.Cities, "Id", "Name", actualNumberOfShipments.ArrivalCityId);
            ViewBag.DepartureCityId = new SelectList(db.Cities, "Id", "Name", actualNumberOfShipments.DepartureCityId);
            return View(actualNumberOfShipments);
        }

        // GET: ActualNumberOfShipments/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ActualNumberOfShipments actualNumberOfShipments = await db.Actuals.FindAsync(id);
            if (actualNumberOfShipments == null)
            {
                return HttpNotFound();
            }
            return View(actualNumberOfShipments);
        }

        // POST: ActualNumberOfShipments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ActualNumberOfShipments actualNumberOfShipments = await db.Actuals.FindAsync(id);
            db.Actuals.Remove(actualNumberOfShipments);
            await db.SaveChangesAsync();
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
