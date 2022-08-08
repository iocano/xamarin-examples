using AppForm.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppForm
{
    public partial class MainPage : ContentPage
    {

        private int _lastId = 2;


        public ObservableCollection<Contact> _contacts = new ObservableCollection<Contact>
        {
            new Contact{Id = 1, FirstName = "User", LastName = "A", Phone = "6865553434", Email = "mail1@host1.com"},
            new Contact{Id = 2, FirstName = "User", LastName = "B", Phone = "6865551234", Email = "mail2@host1.com"},
        };

        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;
        }

        protected override void OnAppearing()
        {
            contactList.IsRefreshing = true;
            contactList.ItemsSource = _contacts;
            contactList.IsRefreshing = false;
        }


        private void OnToolAddClicked(object sender, EventArgs e)
        {
            var page = new ContactDetailPage();

            // invoked on ContactDetailPage code
            page.ContactAdded += (source, contact) =>
            {
                contact.Id = ++_lastId;
                _contacts.Add(contact);
            };

            Navigation.PushAsync(page);
        }

        private void DeleteContactClicked(object sender, EventArgs e)
        {
            var menuItem = sender as MenuItem;
            if (menuItem.CommandParameter is Contact contact)
            {
                _contacts.Remove(contact);
            }

        }

        private void OnContactSelected(object sender, SelectedItemChangedEventArgs e)
        {
            // avoid fire twice event on double tap
            if (contactList.SelectedItem == null)
                return;

            var selectedContact = e.SelectedItem as Contact;

            // remove highlight
            contactList.SelectedItem = null;

            var page = new ContactDetailPage(selectedContact);

            // invoked on ContactDetailPage code
            page.ContactUpdated += (source, contact) =>
            {
                var dbContact = _contacts.Single(c => c.Id == contact.Id);
                dbContact.FirstName = contact.FirstName;
                dbContact.LastName = contact.LastName;
                dbContact.Phone = contact.Phone;
                dbContact.Email = contact.Email;
                dbContact.IsBlocked = contact.IsBlocked;
            };

            Navigation.PushAsync(page);
        }
    }
}
