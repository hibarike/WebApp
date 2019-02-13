using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class PlanFactInitializer : DropCreateDatabaseAlways<PlanFactContext>
    {
        
            protected override void Seed(PlanFactContext db)
            {
                db.Cities.Add(new City { Name = "Днепр"});
                db.Cities.Add(new City { Name = "Киев"});
                db.Cities.Add(new City { Name = "Одесса"});
                
                base.Seed(db);
            }
        
    }
}