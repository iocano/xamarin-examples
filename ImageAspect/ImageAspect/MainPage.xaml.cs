using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ImageAspect
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            image1.Source = ImageSource.FromResource("ImageAspect.Images.donut.png");
        }
    }
}
