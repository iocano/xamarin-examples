using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ImageFromURI
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            var layout = new StackLayout();
            var image1 = new Image();
            var image2 = new Image();
            layout.Children.Add(image1);
            layout.Children.Add(image2);

            // Option 1: Casting to UriImageSource
            var imageSource1 = (UriImageSource)ImageSource.FromUri(new Uri("https://picsum.photos/id/1018/1920/1080"));
            image1.Source = imageSource1;

            // Option 2: Better 
            var imageSource2 = new UriImageSource { Uri = new Uri("https://picsum.photos/id/1018/1920/1080") };
            image2.Source = imageSource2;


            // Image cache
            imageSource2.CachingEnabled = false;
            //Expiration time
            imageSource2.CacheValidity = TimeSpan.FromHours(1);

            Content = layout;
        }
    }
}
