using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class ActualInMonth
    {
        //id месяца
        public int Id { get; set; }
        //Фактическое количество перевозок по дням
        public ICollection<ActualInDay> ActualNumberOfShipmentsByDay { get; set; }

        ActualInMonth()
        {
            ActualNumberOfShipmentsByDay = new List<ActualInDay>();
        }
    }
}