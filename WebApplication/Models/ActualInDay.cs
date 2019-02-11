using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class ActualInDay
    {
        //Id дня
        public int Id { get; set; }
        //фактическое количество перевозок
        public int NumberOfShipments { get; set; }
    }
}