using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FlayoutLayout
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FlayoutMenuPage : ContentPage
    {
        public FlayoutMenuPage()
        {
            InitializeComponent();

            //menuOptions.ItemsSource = new List<FlyoutItemPage>
            //{
            //    new FlyoutItemPage{Title="Home", TargetPage = typeof(HomePage), IconSource="home"},
            //    new FlyoutItemPage{Title="Courses Offered", TargetPage = typeof(CoursesPage), IconSource="courses"},
            //    new FlyoutItemPage{Title="About Us", TargetPage = typeof(AboutPage), IconSource="about"},
            //    new FlyoutItemPage{Title="Logout", TargetPage = typeof(LogoutPage), IconSource="logout"},
            //};
        }
    }
}