using System;
using System.Collections.Generic;
using System.Text;

namespace AppListGroupSearch.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public string Location { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }

        public string Period
        {
            get => String.Format("{0} - {1}", CheckIn, CheckOut); 
        }
    }
}
