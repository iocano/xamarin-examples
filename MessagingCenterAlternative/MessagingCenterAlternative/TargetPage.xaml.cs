using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MessagingCenterAlternative
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TargetPage : ContentPage
    {
        public event EventHandler<double> SliderValueChanged;
        public TargetPage(string sliderValue)
        {
            InitializeComponent();
            double.TryParse(sliderValue, out double value);
            slider.Value = value;   
        }  

        void OnValueChanged(object sender, ValueChangedEventArgs e)
            => SliderValueChanged?.Invoke(this, e.NewValue);
    }
}