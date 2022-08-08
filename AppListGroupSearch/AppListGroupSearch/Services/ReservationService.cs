using AppListGroupSearch.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace AppListGroupSearch.Services
{
    public class ReservationService
    {
        public readonly ObservableCollection<Reservation> _reservations;

        public ReservationService()
        {
            _reservations = new ObservableCollection<Reservation>
            {
               new Reservation
               {
                  Id = 1,
                  Location = "Springfield, CA, United States",
                  CheckIn = new DateTime(2015, 7, 10),
                  CheckOut = new DateTime(2015, 10, 10),
               },
               new Reservation
               {
                   Id = 2,
                   Location = "Topanga CA, United States",
                   CheckIn = new DateTime(2015, 9, 2),
                  CheckOut = new DateTime(2015, 10, 2)
               }
            };
        }

        public ObservableCollection<Reservation> GetReservations(string filter = null)
        {
            if (string.IsNullOrEmpty(filter))
            {
                return _reservations;
            }

            filter = filter.ToLower();
            return new ObservableCollection<Reservation>(_reservations.Where(s => s.Location.ToLower().Contains(filter)));
        }

        public void DeleteSearch(int searchId)
            => _reservations.Remove(_reservations.Single(s => s.Id == searchId));
    }
}
