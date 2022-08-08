using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace StackLayout
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            var layout = new Xamarin.Forms.StackLayout
            {
                BackgroundColor = Color.Gold,
                Orientation = StackOrientation.Horizontal,
                Padding = new Thickness(40),
                Spacing = 20,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
            };
            var innerLayout = new Xamarin.Forms.StackLayout
            {
                Children =
                {
                    new Image {Source = "https://place-hold.it/100", WidthRequest=100, HeightRequest=100},
                    new Label {Text = "Label 1", BackgroundColor = Color.Silver}
                }
            };

            layout.Children.Add(innerLayout);
            layout.Children.Add(new Label { Text = "Label 2", BackgroundColor = Color.Silver });
            layout.Children.Add(new Label { Text = "Label 3", BackgroundColor = Color.Silver });
            Content = layout;
        }
    }
}
