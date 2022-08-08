using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppLoadImages
{
    public partial class MainPage : ContentPage
    {
        private int _currentImageIndex = 1000;
        private readonly string _uriPlaceholder = "https://picsum.photos/id/{0}/1920/1080";
        private readonly UriImageSource _uriImageSource;

        public MainPage()
        {
            InitializeComponent();

            var uriString = string.Format(_uriPlaceholder, _currentImageIndex);

            _uriImageSource = new UriImageSource
            {
                Uri = new Uri(uriString),
                CachingEnabled = false
            };

            image.Source = _uriImageSource;
            imageUrl.Text = uriString;
        }

        private void OnClick(object sender, EventArgs e)
        {
            var button = sender as Button;
            var classId = button.ClassId;

            _currentImageIndex += (classId == "left") ? -1 : 1;

            if (_currentImageIndex > 1009)
            {
                _currentImageIndex = 1000;
            }
            else if(_currentImageIndex < 1000)
            {
                _currentImageIndex = 1009;
            }

            var uriString = string.Format(_uriPlaceholder, _currentImageIndex);
            imageUrl.Text = uriString;

            _uriImageSource.Uri = new Uri(uriString);
        }
    }
}
