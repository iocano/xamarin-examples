using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AbsoluteLayout
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            var layout = new Xamarin.Forms.AbsoluteLayout();
            var boxView1 = new BoxView { Color = Color.Aqua };
            var boxView2 = new BoxView { Color = Color.White };
            var button1 = new Button { Text = "Get Started", BackgroundColor = Color.Silver, TextColor = Color.White };

            layout.Children.Add(boxView1, new Rectangle(0, 0, 1, 1), AbsoluteLayoutFlags.All);
            layout.Children.Add(boxView2, new Rectangle(0.5, 0.1, 100, 100), AbsoluteLayoutFlags.PositionProportional);
            layout.Children.Add(button1, new Rectangle(0, 1, 1, 50), AbsoluteLayoutFlags.PositionProportional | AbsoluteLayoutFlags.WidthProportional);

            // Change postion/size (x, y, w, h)
            // Xamarin.Forms.AbsoluteLayout.SetLayoutBounds(boxView1, new Rectangle(0, 0, 2, 2));

            // Change units
            // Xamarin.Forms.AbsoluteLayout.SetLayoutFlags(boxView1, AbsoluteLayoutFlags.HeightProportional);


            Content = layout;

        }
    }
}
