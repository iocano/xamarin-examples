using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ListViewComplex
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            // Complex list CellTypes
            list1.ItemsSource = GetContactList();
            list2.ItemsSource = GetContactList();
            list3.ItemsSource = GetContactList();

            // Grouping Items
            list4.ItemsSource = GetContactGroups();
        }

        // Complex list CellTypes
        private IEnumerable<Contact> GetContactList()
        {
            return new List<Contact>
            {
                new Contact
                {
                    Name = "Name1",
                    ImageUrl = "https://faces-img.xcdn.link/image-lorem-face-11.jpg",
                    Status = "Available"
                },
                new Contact
                {
                    Name = "Name2",
                    ImageUrl = "https://faces-img.xcdn.link/image-lorem-face-17.jpg",
                    Status = "Available"
                }
            };
        }

        // Grouping Items
        private List<ContactGroup> GetContactGroups()
        {
            return new List<ContactGroup>
            {
                new ContactGroup("A", "A")
                {
                    new Contact
                    {
                        Name = "Name1",
                        ImageUrl = "https://faces-img.xcdn.link/image-lorem-face-11.jpg",
                        Status = "Available"
                    },
                },
                new ContactGroup("T", "T")
                {
                    new Contact
                    {
                        Name = "Name2",
                        ImageUrl = "https://faces-img.xcdn.link/image-lorem-face-17.jpg",
                        Status = "Available"
                    },
                }
            };
        }

        // Complex list CellTypes
    }
    public class Contact
    {
        public string Name { get; set; }
        public string Status { get; set; }
        public string ImageUrl { get; set; }
    }

    // Grouping Items
    public class ContactGroup : List<Contact>
    {
        public string Title { get; set; }
        public string ShortTitle { get; set; }
        public ContactGroup(string title, string shortTitle)
        {
            Title = title;
            ShortTitle = shortTitle;
        }

    }

}
