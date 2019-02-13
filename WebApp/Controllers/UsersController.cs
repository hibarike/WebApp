using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users
        [Authorize(Roles = "admin")]
        public ActionResult Index()
        {
            //IList<string> roles = new List<string> { "Роль не определена" };
            //ApplicationUserManager userManager = HttpContext.GetOwinContext()
            //                                        .GetUserManager<ApplicationUserManager>();
            //ApplicationUser user = userManager.FindByEmail(User.Identity.Name);

            //if (user != null)
            //    roles = userManager.GetRoles(user.Id);
            //return View(roles);
            var context = new ApplicationDbContext();
            var allUsers = context.Users.ToList();
            //ViewBag.llRoles = context.Roles.ToList();
            IList<string> roles = new List<string> { "Роль не определена" };
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
        
        
       
    }
}