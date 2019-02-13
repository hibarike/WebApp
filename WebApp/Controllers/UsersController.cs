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

             ApplicationUser user = userManager.FindByEmail(User.Identity.Name);
            if (user != null)
                roles = userManager.GetRoles(user.Id);
            
        
            
            return View(allUsers);
            
        }
        class UserRole
        {
            static ApplicationUserManager userManager { get; set; }
            ApplicationUser user { get; set; }
            IList<string> roles
            {
                get
                {
                    IList<string> roles = new List<string> { "Роль не определена" };
                  
                   
                    if (user != null)
                        roles = userManager.GetRoles(user.Id);
                    return roles;
                }
            }
        };
        IList<UserRole> userRoles;
    }
}