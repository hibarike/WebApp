using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class Plan_Fact
    {
        //ID
        public int ID { get; set; }
        
        //Плановое количество перевозок
        public int PlannedNumberOfShipments { get; set; }
        //Фактическое количество перевозок между двумя городами по дням
        public int? ActualNumberOfShipmentsID { get; set; }

        public ActualNumberOfShipments ActualNumberOfShipmentsByDay{ get; set;}

        //Фактическое количество перевозок
        public int ActualNumberOfShipments { get; set; }


    }
}