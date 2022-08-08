using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PlatformSpecific
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            switch (Device.RuntimePlatform)
            {
                case Device.Android:
                    Padding = new Thickness(10, 20, 0, 0);
                    break;
                case Device.iOS:
                    Padding = new Thickness(0, 20, 0, 0);
                    break;
                case Device.WPF:
                    Padding = new Thickness(30, 20, 0, 0);
                    break;
            }

        }
    }
}
