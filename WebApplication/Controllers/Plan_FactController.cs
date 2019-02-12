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
    public class Plan_FactController : Controller
    {
        private PlanFactContext db = new PlanFactContext();

        // GET: Plan_Fact
        public async Task<ActionResult> Index()
        {
            var plan_Facts = db.Plan_Facts.Include(p => p.ActualNumberOfShipmentsByDay);
            return View(await plan_Facts.ToListAsync());
        }

        // GET: Plan_Fact/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plan_Fact plan_Fact = await db.Plan_Facts.FindAsync(id);
            if (plan_Fact == null)
            {
                return HttpNotFound();
            }
            return View(plan_Fact);
        }

        // GET: Plan_Fact/Create
        public ActionResult Create()
        {
            ViewBag.ActualNumberOfShipmentsID = new SelectList(db.Actuals, "Id", "Id");
            return View();
        }

        // POST: Plan_Fact/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,PlannedNumberOfShipments,ActualNumberOfShipmentsID,ActualNumberOfShipments")] Plan_Fact plan_Fact)
        {
            if (ModelState.IsValid)
            {
                db.Plan_Facts.Add(plan_Fact);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ActualNumberOfShipmentsID = new SelectList(db.Actuals, "Id", "Id", plan_Fact.ActualNumberOfShipmentsID);
            return View(plan_Fact);
        }

        // GET: Plan_Fact/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plan_Fact plan_Fact = await db.Plan_Facts.FindAsync(id);
            if (plan_Fact == null)
            {
                return HttpNotFound();
            }
            ViewBag.ActualNumberOfShipmentsID = new SelectList(db.Actuals, "Id", "Id", plan_Fact.ActualNumberOfShipmentsID);
            return View(plan_Fact);
        }

        // POST: Plan_Fact/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,PlannedNumberOfShipments,ActualNumberOfShipmentsID,ActualNumberOfShipments")] Plan_Fact plan_Fact)
        {
            if (ModelState.IsValid)
            {
                db.Entry(plan_Fact).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ActualNumberOfShipmentsID = new SelectList(db.Actuals, "Id", "Id", plan_Fact.ActualNumberOfShipmentsID);
            return View(plan_Fact);
        }

        // GET: Plan_Fact/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plan_Fact plan_Fact = await db.Plan_Facts.FindAsync(id);
            if (plan_Fact == null)
            {
                return HttpNotFound();
            }
            return View(plan_Fact);
        }

        // POST: Plan_Fact/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Plan_Fact plan_Fact = await db.Plan_Facts.FindAsync(id);
            db.Plan_Facts.Remove(plan_Fact);
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
