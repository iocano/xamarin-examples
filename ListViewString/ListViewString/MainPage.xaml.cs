using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ListViewString
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();

			list2.ItemsSource = new List<string> { "Name1", "Name2"};
			list3.ItemsSource = new List<string> { "Cujo", "It", "Carrie" };
			list4.ItemsSource = new List<string> { "The Raven", "The Oval Portrait"};
		}
	}
}
