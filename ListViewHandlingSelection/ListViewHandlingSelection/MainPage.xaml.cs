using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ListViewHandlingSelection
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            list.ItemsSource = GetContactList();
        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var contact = e.Item as Contact;
            DisplayAlert("Tapped", contact.Name, "Ok");
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (list.SelectedItem == null)
                return;

            list.SelectedItem = null;

            var contact = e.SelectedItem as Contact;
            DisplayAlert("Selected", contact.Name, "Ok");
        }

        private IEnumerable<Contact> GetContactList()
        {
            return new List<Contact>
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

    }
    public class Contact
    {
        public string Name { get; set; }
        public string Status { get; set; }
    }

}
