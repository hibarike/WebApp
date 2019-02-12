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
       
        
        public ActionResult Index()
        {
          
            return View();
        }
        
        
    }
}