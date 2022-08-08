using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PlatformSpecificImage
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
			button1.ImageSource = "user.png";

			//Diferent image for each platform
			//switch(Device.RuntimePlatform) {
			//    case Device.iOS: button1.ImageSource = "imageIOS.png";break;
			//    case Device.Android: button1.ImageSource = "imageAndroid.png";break;
			//    case Device.WPF: button1.ImageSource = "/Images/imageWin.png";break;
			//}
		}
	}
}
