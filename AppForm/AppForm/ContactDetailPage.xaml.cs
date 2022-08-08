using AppForm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppForm
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactDetailPage : ContentPage
    {
        public EventHandler<Contact> ContactUpdated { get; set; }
        public EventHandler<Contact> ContactAdded { get; set; }

        public ContactDetailPage(Contact contact = null)
        {
            InitializeComponent();
            if (contact == null)
            {
                BindingContext = new Contact();
            }
            else
            {
                // creating new contact to avoid overwrite data
                BindingContext = new Contact
                {
                    Id = contact.Id,
                    FirstName = contact.FirstName,
                    LastName = contact.LastName,
                    Email = contact.Email,
                    Phone = contact.Phone,
                    IsBlocked = contact.IsBlocked
                };
            }
        }

        private void SaveButtonClicked(object sender, EventArgs e)
        {

            var contact = BindingContext as Contact;
            if (string.IsNullOrWhiteSpace(contact.FullName))
            {
                DisplayAlert("Error", "Please enter the name.", "Ok");
                return;
            }

            if (contact.Id == 0)
            {
                ContactAdded?.Invoke(this, contact);
            }
            else
            {
                ContactUpdated?.Invoke(this, contact);
            }
            Navigation.PopAsync();
        }
    }
}