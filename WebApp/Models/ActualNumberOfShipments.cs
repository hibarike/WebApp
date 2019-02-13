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
        //Планируемое
        public int PlanedNumberOfShipments { get; set; }

        //Фактическое за месяц
        public int? ActualInMonthId { get; set; }
        public ActualInMonth ActualInMonthForThisWay { get; set; }
        //Фактическое сумма

        public int ActualNumberOfShipment
        {
            get
            {
                if(ActualInMonthForThisWay !=null)
                {
                    int summ = 0;
                    foreach (var item in ActualInMonthForThisWay.ActualInDays)
                        summ += item;
                    return summ;

                }
                else
                {
                    return 0;
                }
            }

            
        }


    }
}