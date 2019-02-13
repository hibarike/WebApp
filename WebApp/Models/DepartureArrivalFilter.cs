
using System.Collections.Generic;
using System.Web.Mvc;

namespace WebApp.Models
{
    public class DepartureArrivalFilter
    {
        public IEnumerable<ActualNumberOfShipments> Actuals { get; set; }
        public SelectList Departure { get; set; }
        public SelectList Arrival { get; set; }
    }
}