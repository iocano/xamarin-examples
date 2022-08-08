using AppNavigation.Models;
using AppNavigation.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppNavigation
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactListPage : ContentPage
    {
        public ObservableCollection<UserActivity> ContactActivityList { get; set; }

        public ContactListPage()
        {
            InitializeComponent();
            ContactActivityList = UserActivityService.Activities;
            BindingContext = this;
        }

        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            var userActivity = e.SelectedItem as UserActivity;
            contactActivity.SelectedItem = null;
            await Navigation.PushAsync(new ContactPage(userActivity.UserId)); 
        }

    }
}