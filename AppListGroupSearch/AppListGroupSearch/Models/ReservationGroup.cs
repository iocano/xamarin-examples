using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace AppListGroupSearch.Models
{
    internal class ReservationGroup : ObservableCollection<Reservation>
    {
        public string Title { get; set; }

        public ReservationGroup(string title, ObservableCollection<Reservation> reservations) 
            : base (reservations)
        {
            Title = title;
        }
    }
}
