using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppDeviceSpecific
{
    public partial class MainPage : ContentPage
    {
        private readonly List<string> _quotes;
        private int _currentIndex;

        public MainPage()
        {
            InitializeComponent();
            _currentIndex = 0;
            _quotes = new List<string> { "A", "B", "C", "D" };
            Quote.Text = _quotes[0].ToString();
        }

        private void OnClick(object sender, EventArgs e)
        {
            if (++_currentIndex >= _quotes.Count)
                _currentIndex = 0;
            Quote.Text = _quotes[_currentIndex].ToString();
        }
    }

}
