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
    public class ActualInDaysController : Controller
    {
        private PlanFactContext db = new PlanFactContext();

        // GET: ActualInDays
        public async Task<ActionResult> Index()
        {
            var actualInDays = db.ActualInDays.Include(a => a.ActualInMonthD);
            return View(await actualInDays.ToListAsync());
        }

        // GET: ActualInDays/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ActualInDay actualInDay = await db.ActualInDays.FindAsync(id);
            if (actualInDay == null)
            {
                return HttpNotFound();
            }
            return View(actualInDay);
        }

        // GET: ActualInDays/Create
        public ActionResult Create()
        {
            ViewBag.ActualInMonthId = new SelectList(db.ActualInMonths, "Id", "Id");
            return View();
        }

        // POST: ActualInDays/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,DayInMonth,NumberOfShipments,ActualInMonthId")] ActualInDay actualInDay)
        {
            if (ModelState.IsValid)
            {
                db.ActualInDays.Add(actualInDay);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ActualInMonthId = new SelectList(db.ActualInMonths, "Id", "Id", actualInDay.ActualInMonthId);
            return View(actualInDay);
        }

        // GET: ActualInDays/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ActualInDay actualInDay = await db.ActualInDays.FindAsync(id);
            if (actualInDay == null)
            {
                return HttpNotFound();
            }
            ViewBag.ActualInMonthId = new SelectList(db.ActualInMonths, "Id", "Id", actualInDay.ActualInMonthId);
            return View(actualInDay);
        }

        // POST: ActualInDays/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,DayInMonth,NumberOfShipments,ActualInMonthId")] ActualInDay actualInDay)
        {
            if (ModelState.IsValid)
            {
                db.Entry(actualInDay).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ActualInMonthId = new SelectList(db.ActualInMonths, "Id", "Id", actualInDay.ActualInMonthId);
            return View(actualInDay);
        }

        // GET: ActualInDays/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ActualInDay actualInDay = await db.ActualInDays.FindAsync(id);
            if (actualInDay == null)
            {
                return HttpNotFound();
            }
            return View(actualInDay);
        }

        // POST: ActualInDays/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ActualInDay actualInDay = await db.ActualInDays.FindAsync(id);
            db.ActualInDays.Remove(actualInDay);
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
