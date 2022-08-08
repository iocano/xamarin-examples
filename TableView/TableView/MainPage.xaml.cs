using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TableView
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

		private void ViewCell_Tapped(object sender, EventArgs e)
		{
			var page = new ContactMethodsPage();
			// on list ItemSelected
			page.ContactMethods.ItemSelected += (sorce, args) => {
				// set main page label text
				contactMethod.Text = args.SelectedItem.ToString();
				// return to main page
				Navigation.PopAsync();
			};
			// go to contact method list page
			Navigation.PushAsync(page);
		}
	}
}
