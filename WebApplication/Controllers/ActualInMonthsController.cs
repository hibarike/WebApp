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
    public class ActualInMonthsController : Controller
    {
        private PlanFactContext db = new PlanFactContext();

        // GET: ActualInMonths
        public async Task<ActionResult> Index()
        {
            return View(await db.ActualInMonths.ToListAsync());
        }

        // GET: ActualInMonths/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ActualInMonth actualInMonth = await db.ActualInMonths.FindAsync(id);
            if (actualInMonth == null)
            {
                return HttpNotFound();
            }
            return View(actualInMonth);
        }

        // GET: ActualInMonths/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ActualInMonths/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id")] ActualInMonth actualInMonth)
        {
            if (ModelState.IsValid)
            {
                db.ActualInMonths.Add(actualInMonth);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(actualInMonth);
        }

        // GET: ActualInMonths/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ActualInMonth actualInMonth = await db.ActualInMonths.FindAsync(id);
            if (actualInMonth == null)
            {
                return HttpNotFound();
            }
            return View(actualInMonth);
        }

        // POST: ActualInMonths/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id")] ActualInMonth actualInMonth)
        {
            if (ModelState.IsValid)
            {
                db.Entry(actualInMonth).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(actualInMonth);
        }

        // GET: ActualInMonths/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ActualInMonth actualInMonth = await db.ActualInMonths.FindAsync(id);
            if (actualInMonth == null)
            {
                return HttpNotFound();
            }
            return View(actualInMonth);
        }

        // POST: ActualInMonths/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ActualInMonth actualInMonth = await db.ActualInMonths.FindAsync(id);
            db.ActualInMonths.Remove(actualInMonth);
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
