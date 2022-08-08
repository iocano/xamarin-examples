using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MessagingCenter
{
    public partial class MainPage : ContentPage
    {
        public MainPage() => InitializeComponent();
        void OnClick(object sender, EventArgs e)
        {
            var page = new TargetPage(label.Text);
            Xamarin.Forms.MessagingCenter.Subscribe<TargetPage, double>(
                this, "SliderValueChanged", OnSliderValueChanged);
            Navigation.PushAsync(page);
            Xamarin.Forms.MessagingCenter.Unsubscribe<MainPage>(this, "SliderValueChanged");
        }

        private void OnSliderValueChanged(TargetPage source, double newValue)
            => label.Text = newValue.ToString();
    }
}
