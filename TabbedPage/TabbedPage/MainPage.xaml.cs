using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TabbedPage
{
    public partial class MainPage : Xamarin.Forms.TabbedPage
    {
        public MainPage()
        {
            InitializeComponent();

            // ContantPage created at fly
            //var homePage = new ContentPage
            //{
            //    Title = "Home",
            //    Content = new Label { Text = "Home page" }
            //};
            //Children.Add(homePage);
        }
    }
}
