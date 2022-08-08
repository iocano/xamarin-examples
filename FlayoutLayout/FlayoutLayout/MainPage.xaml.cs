using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FlayoutLayout
{
    public partial class MainPage : FlyoutPage
    {
        public MainPage()
        {
            InitializeComponent();
            flyout.listView.ItemSelected += OnSelectedItem;
        }
        private void OnSelectedItem(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem is FlyoutItemPage item)
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetPage, item));
                flyout.listView.SelectedItem = null;
                // hide flyout menu 
                IsPresented = false;
            }
        }
    }


}
