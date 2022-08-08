using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MessagingCenterAlternative
{
    public partial class MainPage : ContentPage
    {
        public MainPage() => InitializeComponent();

        void OnClick(object sender, EventArgs e)
        {
            var page = new TargetPage(label.Text);
            page.SliderValueChanged += OnSliderValueChanged;
            Navigation.PushAsync(page);
        }

        private void OnSliderValueChanged(object source, double newValue)
            => label.Text = newValue.ToString();

    }
}
