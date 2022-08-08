using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ListViewContextAction
{
    public partial class MainPage : ContentPage
    {
        // Use ObservableCollection to track changes
        private ObservableCollection<Contact> _contacts { get; set; }

        public MainPage()
        {
            InitializeComponent();
            _contacts = GetContactList();
            list.ItemsSource = _contacts;
        }

        private ObservableCollection<Contact> GetContactList()
        {
            return new ObservableCollection<Contact> 
            {
                    new Contact 
                    {
                        Name = "Name1",
                        Status = "Available"
                    },
                    new Contact 
                    {
                        Name = "Name2",
                        Status = "Available"
                    }
                };
        }

        private void Call_Clicked(object sender, EventArgs e)
        {
            var menuItem = sender as MenuItem;
            var contact = menuItem.CommandParameter as Contact;
            DisplayAlert("Call", contact.Name, "OK");
        }

        private void Delete_Clicked(object sender, EventArgs e)
        {
            var menuItem = sender as MenuItem;
            var contact = menuItem.CommandParameter as Contact;
            _contacts.Remove(contact);
        }

        private void list_ItemSelected(object sender, SelectedItemChangedEventArgs e)
            => list.SelectedItem = null;

    }
    public class Contact
    {
        public string Name { get; set; }
        public string Status { get; set; }
    }
}
