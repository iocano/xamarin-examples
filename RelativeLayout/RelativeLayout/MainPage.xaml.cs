using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RelativeLayout
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            var layout = new Xamarin.Forms.RelativeLayout();
            //var box1 = new BoxView { Color = Color.Aqua };
            var box1 = new BoxView { Color = Color.Red };
            layout.Children.Add(box1,
                widthConstraint: Constraint.RelativeToParent(parent => parent.Width),
                heightConstraint: Constraint.RelativeToParent(parent => parent.Height * 0.3));

            var box2 = new BoxView { Color = Color.Silver };
            layout.Children.Add(box2,
                yConstraint: Constraint.RelativeToView(box1, (l, e) => e.Height + 20));

            Content = layout;
        }
    }
}
