using AppListGroupSearch.Models;
using AppListGroupSearch.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppListGroupSearch
{
    public partial class MainPage : ContentPage
    {
        private readonly ReservationService _reservationService;
        private List<ReservationGroup> _reservationGroups;

        public MainPage()
        {
            InitializeComponent();
            _reservationService = new ReservationService();
            listView.ItemsSource = GetGroups();
        }

        private void OnRefresh(object sender, EventArgs e)
        {
            listView.ItemsSource = GetGroups(searchBar.Text);
            listView.EndRefresh();
        }

        private void OnSearching(object sender, TextChangedEventArgs e)
            => listView.ItemsSource = GetGroups(e.NewTextValue);

        private List<ReservationGroup> GetGroups(string filter = "")
        {
            _reservationGroups = new List<ReservationGroup>
            {
                new ReservationGroup("Last reservations", _reservationService.GetReservations(filter))
            };
            return _reservationGroups;
        }

        private void OnDelete(object sender, EventArgs e)
        {
            var menuItem = sender as MenuItem;
            var search = menuItem.CommandParameter as Reservation;
            // remove from the listView (Observable is in memory)
            _reservationGroups[0].Remove(search);
            // remove from the service
            _reservationService.DeleteSearch(search.Id);
        }

    }
}
