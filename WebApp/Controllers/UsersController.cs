using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Contexts;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class UsersController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        
        // GET: Users
        [Authorize(Roles = "admin")]
        public ActionResult Index()
        {
            
            
            var allUsers = db.Users.ToList();
           // IList<string> roles = new List<string> { "Роль не определена" };
            ApplicationUserManager userManager = HttpContext.GetOwinContext()
                                                    .GetUserManager<ApplicationUserManager>();
            List<UserRole> UserRoles = new List<UserRole>();
            foreach (var item in allUsers)
            {
                var _user = userManager.FindByEmail(User.Identity.Name);
                UserRoles.Add(new UserRole
                {
                    user = _user,
                    roles = userManager.GetRoles(_user.Id)
                });
            }
            
            
        
            
            return View(UserRoles);
            
        }
        // GET: Cities/Edit/5
        [Authorize(Roles = "admin")]
        public async Task<ActionResult> Edit(int? id)
        {
            ApplicationUserManager userManager = HttpContext.GetOwinContext()
                                                       .GetUserManager<ApplicationUserManager>();

            var allUsers = db.Users.ToList();
            List<UserRole> UserRoles = new List<UserRole>();
            foreach (var item in allUsers)
            {
                var _user = userManager.FindByEmail(User.Identity.Name);
                UserRoles.Add(new UserRole
                {
                    user = _user,
                    roles = userManager.GetRoles(_user.Id)
                });
            }
           
            return View(UserRoles);
        }

        // POST: Cities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,RolesId")] ApplicationUser user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: Cities/Delete/5
        [Authorize(Roles = "admin")]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Cities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ApplicationUser user = db.Users.Find(id);
            db.Users.Remove(user);
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