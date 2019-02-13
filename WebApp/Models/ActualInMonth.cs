using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class ActualInMonth
    {
        //id месяца
        public int Id { get; set; }
        //Фактическое количество перевозок по дням

        [NotMapped]
        public IEnumerable<int> ActualInDays
        {
            get
            {
                var tab = InternalDays.Split(',');
                return tab.Select(int.Parse).AsEnumerable();
            }
            set { InternalDays = string.Join(",", value); }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public string InternalDays { get; set; }
    }
}