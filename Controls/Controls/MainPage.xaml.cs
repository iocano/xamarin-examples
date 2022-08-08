using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Controls
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            // Picker with dynamic options
            foreach (var option in _options) { picker2.Items.Add(option.Name); }
        }

        private void OnSwitchToggled(object sender, ToggledEventArgs e)
            => DisplayAlert("Switch", "Switch: " + e.Value, "Ok");

        private void OnSliderValueChanged(object sender, ValueChangedEventArgs e)
        {
            //int oldVal = (int)e.OldValue;
            //int newVal = (int)e.NewValue;
            //DisplayAlert("Slider", "Old: " + oldVal + " New: " + newVal, "Ok");
        }

        private void OnStepperValueChanged(object sender, ValueChangedEventArgs e)
        {
            //var oldVal = e.OldValue;
            //var newVal = e.NewValue;
            //DisplayAlert("Stepper", "Old: " + oldVal + " New: " + newVal, "Ok");
        }

        private void OnPassCompleted(object sender, EventArgs e)
            => DisplayAlert("Pass", "Complete", "Ok"); 

        private void OnEntryTextChanged(object sender, TextChangedEventArgs e)
        {
            var oldVal = e.OldTextValue;
            var newVal = e.NewTextValue;
            DisplayAlert("Entry", "Old: " + oldVal + " New: " + newVal, "Ok");
        }

        private void OnPicker1Selected(object sender, EventArgs e)
        {
            var option = picker1.Items[picker1.SelectedIndex];
            DisplayAlert("Selection", option, "Ok");
        }

        // Picker with dynamic options
        private List<Option> _options = new List<Option>
        {
            new Option { Id = 1, Name = "Opt 1" },
            new Option { Id = 2, Name = "Opt 2" }
        };

        private void OnPicker2Selected(object sender, EventArgs e)
        {
            var name = picker2.Items[picker2.SelectedIndex];
            var option = _options.Single(o => o.Name == name);
            DisplayAlert("Selected", "Name: " + option.Name + " Id: " + option.Id, "Ok");
        }

        // DatePicker
        private void OnDateSelected(object sender, DateChangedEventArgs e)
            => DisplayAlert("Date", e.NewDate.ToString(), "Ok");

        // TimePicker
        private void OnTimePickerUnfocused(object sender, FocusEventArgs e)
            => DisplayAlert("time", timePicker.Time.ToString(), "Ok");
    }

    // Picker with dynamic options
    public class Option
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

}
