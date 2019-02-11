using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class ActualNumberOfShipments
    {
        
        //ID
        public int Id { get; set; }
        //Город отправления
        public int? DepartureCityId { get; set; }
        public City DepartureCity { get; set; }
        //Город прибытия
        public int? ArrivalCityId { get; set; }
        public City ArrivalCity { get; set; }
        //Фактическое количество перевозок по дням
        public ICollection<ActualInDay> ActualNumberOfShipmentsByDay { get; set; }

        ActualNumberOfShipments()
        {
            ActualNumberOfShipmentsByDay = new List<ActualInDay>();
        }

    }
}