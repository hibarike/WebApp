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


namespace WebApp.Controllers
{
    public class SecondReportController : Controller
    {
        private PlanFactContext db = new PlanFactContext();
        // GET: SecondReport
        public ActionResult Index()
        {
            IQueryable<ActualNumberOfShipments> actuals = db.Actuals.Include(a => a.ActualInMonthForThisWay).Include(a => a.ArrivalCity).Include(a => a.DepartureCity);
            IEnumerable<City> cities = db.Cities;
            var DepartureIds = actuals.Select(x => x.DepartureCityId).ToArray();

            cities = db.Cities.Where(p=>DepartureIds.Contains(p.Id));
            
           
            List<SecondReport> second = new List<SecondReport>(); 
            foreach (var item in cities)
            {
                IEnumerable<ActualNumberOfShipments> actual = db.Actuals.Where(p => p.DepartureCity.Name == item.Name);

                second.Add(new SecondReport
                {

                    DepartureCity = item,
                    Actuals = actual
            });
             }
            return View(second);
        }
    }
}