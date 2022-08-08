using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ListViewSearchBar
{
    public partial class MainPage : ContentPage
    {
        private readonly List<Contact> _contacts = new List<Contact>
        {
            new Contact { Name = "Name1", Status = "Available" },
            new Contact { Name = "Name2", Status = "Available" }
        };

        public MainPage()
        {
            InitializeComponent();
            list.ItemsSource = GetContactList();
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
            => list.ItemsSource = GetContactList(e.NewTextValue);

        private IEnumerable<Contact> GetContactList(string search = "")
            => _contacts.Where(c => c.Name.Contains(search));

    }
    public class Contact
    {
        public string Name { get; set; }
        public string Status { get; set; }
    }
}
