using AppContactBook.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppContactBook
{
    public partial class MainPage : ContentPage
    {
        private readonly SQLiteAsyncConnection _connection;

        private ObservableCollection<Contact> _contacts;

        public MainPage()
        {
            InitializeComponent();
            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            await _connection.CreateTableAsync<Contact>();
            var contacts = await _connection.Table<Contact>().ToListAsync();

            if (!contacts.Any())
            {
                await _connection.InsertAllAsync(GetContacts());
            }

            _contacts = new ObservableCollection<Contact>(contacts);
            contactList.ItemsSource = _contacts;
        }

        private ObservableCollection<Contact> GetContacts()
        {
            return new ObservableCollection<Contact>
            {
                new Contact{Id = 1, FirstName = "Name1", LastName = "Surname2", Phone = "6865553434", Email = "mail1@host1.com"},
                new Contact{Id = 2, FirstName = "Name2", LastName = "Surname2", Phone = "6865551234", Email = "mail2@host1.com"},
            };
        }

        private void OnAdd(object sender, EventArgs e)
        {
            var page = new ContactDetailPage();
            page.ContactAdded = (source, contact) =>
            {
                _connection.InsertAsync(contact);
                _contacts.Add(contact);
            };
            Navigation.PushAsync(page);
        }

        private void contactListItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (contactList.SelectedItem == null)
                return;

            var selectedContact = e.SelectedItem as Contact;

            contactList.SelectedItem = null;

            var page = new ContactDetailPage(selectedContact);
            page.ContactUpdated += (source, contact) =>
            {
                var contactInDb = _contacts.Single(c => c.Id == contact.Id);
                contactInDb.FirstName = contact.FirstName;
                contactInDb.LastName = contact.LastName;
                contactInDb.Phone = contact.Phone;
                contactInDb.Email = contact.Email;
                contactInDb.IsBlocked = contact.IsBlocked;

                _connection.UpdateAsync(contactInDb);
            };
            Navigation.PushAsync(page);
        }

        private void OnDeleteItem(object sender, EventArgs e)
        {
            var menuItem = sender as MenuItem;
            var contact = menuItem.CommandParameter as Contact;
            _contacts.Remove(contact);
            _connection.DeleteAsync(contact);
        }
    }
}
