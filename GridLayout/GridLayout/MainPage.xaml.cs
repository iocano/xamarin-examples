using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GridLayout
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            var grid = new Grid
            {
                BackgroundColor = Color.Goldenrod,
                RowSpacing = 40,
                ColumnSpacing = 40,
                RowDefinitions = {
                    new RowDefinition { Height = new GridLength(100, GridUnitType.Absolute) },
                    new RowDefinition { Height = new GridLength(2, GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) }
                },
                ColumnDefinitions = {
                    new ColumnDefinition{Width = GridLength.Auto},
                    new ColumnDefinition{Width = new GridLength(2, GridUnitType.Star)},
                    new ColumnDefinition{Width = new GridLength(1, GridUnitType.Star)},
                }
            };
            var label1 = new Label { Text = "label 1", BackgroundColor = Color.Gold, VerticalOptions = LayoutOptions.Fill };
            var label2 = new Label { Text = "label 2", BackgroundColor = Color.Gold };
            var label3 = new Label { Text = "label 3", BackgroundColor = Color.Gold };
            var label4 = new Label { Text = "label 4", BackgroundColor = Color.Gold };
            var label5 = new Label { Text = "ColumnSpan", BackgroundColor = Color.Gold };
            var label6 = new Label { Text = "Rowspan", BackgroundColor = Color.Gold };

            grid.Children.Add(label1, 0, 0);
            grid.Children.Add(label2, 1, 0);
            grid.Children.Add(label3, 0, 1);
            grid.Children.Add(label4, 1, 1);
            grid.Children.Add(label5, 0, 2);
            grid.Children.Add(label6, 2, 0);

            // set Span AFTER add to grid
            Grid.SetColumnSpan(label5, 3);
            Grid.SetRowSpan(label6, 3);

            // Change row of element
            // Grid.SetRow(label5, 2);
            // Grid.SetColumn(label6, 2);

            Content = grid;

        }
    }
}
