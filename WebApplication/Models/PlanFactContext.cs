using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class PlanFactContext: DbContext
    {
        
       
        public DbSet<City> Cities { get; set; }
        public DbSet<ActualInDay> ActualInDays { get; set; }
        public DbSet<Plan_Fact> Plan_Facts { get; set; }
        public DbSet<ActualNumberOfShipments> Actuals { get; set; }

    }
}