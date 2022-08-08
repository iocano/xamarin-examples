using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DynamicResource
{
    public partial class MainPage : ContentPage
    {
        public MainPage() => InitializeComponent();

        private void Button_Clicked(object sender, EventArgs e)
        {
            Resources["buttonBg"] = Color.Pink;
            Resources["radius"] = 20;
        }
    }
}
