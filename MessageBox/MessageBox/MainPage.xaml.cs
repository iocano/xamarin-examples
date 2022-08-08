using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MessageBox
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            //var response = await DisplayAlert("Save Changes","Are yout sure?","Yes", "No");
            //if (response)
            //    await DisplayAlert("Done", "Your data is saved", "Ok");

            var response = await DisplayActionSheet(
                "Title", "Cancel", "Delete", "Copy", "Message", "Emal");
            await DisplayAlert("Response", response, "Ok");
            
        }
    }
}
