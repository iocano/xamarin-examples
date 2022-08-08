using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BindingData
{
	public partial class MainPage : ContentPage
	{
		public Person Person { get; set; } = new Person { Name = "Name1", Id = 1 };

		public MainPage()
		{
			InitializeComponent();
			//BindingContext = _person; 
			BindingContext = this; 
		}
	}
	public class Person
	{
		public int Id { get; set; }
		public string Name { get; set; }
	}
}
