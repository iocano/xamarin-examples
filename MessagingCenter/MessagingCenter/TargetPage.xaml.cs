using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MessagingCenter
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TargetPage : ContentPage
    {
        public TargetPage(string sliderValue)
        {
            InitializeComponent();
            double.TryParse(sliderValue, out double value);
            slider.Value = value;
        }

        void OnValueChanged(object sender, ValueChangedEventArgs e)
            => Xamarin.Forms.MessagingCenter.Send(this, "SliderValueChanged", e.NewValue);
    }
}