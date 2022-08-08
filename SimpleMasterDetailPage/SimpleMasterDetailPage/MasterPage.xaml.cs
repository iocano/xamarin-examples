using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SimpleMasterDetailPage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterPage : ContentPage
    {
        public MasterPage()
        {
            InitializeComponent();
            list.ItemsSource = new List<Contact>()
            {
                new Contact {Name="Name1", Status = "Available"},
                new Contact {Name="Name2", Status = "Bussy"},
            };
        }

        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (list.SelectedItem == null) { return; }
                
            list.SelectedItem = null; // remove highlight

            var contact = e.SelectedItem as Contact;

            // Ways to send data to detail page:
            // On constructor
            await Navigation.PushAsync(new DetailPage(contact));

            // Setting Contact property
            // Navigation.PushAsync(new DetailPage() { Contact = contact });

            // Setting BindingContext
            // Navigation.PushAsync(new DetailPage() { BindingContext = contact });
        }

    }

    public class Contact
    {
        public string Name { get; set; }
        public string Status { get; set; }
    }
}