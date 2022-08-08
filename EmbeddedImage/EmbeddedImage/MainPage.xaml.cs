using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace EmbeddedImage
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            //image1.Source = ImageSource.FromResource("ProjectNamePCL.Folder.imageName.ext");
            image1.Source = ImageSource.FromResource("EmbeddedImage.Images.donut.png");
        }
    }
}
