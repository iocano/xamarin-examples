using FlyoutPage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FlyoutPage.Sections
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CoursesPage : ContentPage
    {
        public CoursesPage()
        {
            InitializeComponent();
        }

        public CoursesPage(FlyoutItemPage item) : this()
        {
            label.Text = item.Title;
        }
    }
}