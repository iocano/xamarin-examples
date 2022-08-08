using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ListViewRefresh
{
    public partial class MainPage : ContentPage
    {
        private ObservableCollection<Contact> _contacts = new ObservableCollection<Contact> 
        {
            new Contact { Name = "Name1", Status = "Available" },
            new Contact { Name = "Name2", Status = "Available" }
        };

        public MainPage()
        {
            InitializeComponent();
            list.ItemsSource = _contacts;
        }

        private void List_Refreshing(object sender, EventArgs e)
        {
            // simulating new info comming from server
            _contacts.Add( new Contact { Name = "Contact" + _contacts.Count, Status = "Available" });
            list.EndRefresh();
        }

    }
    public class Contact
    {
        public string Name { get; set; }
        public string Status { get; set; }
    }
}
