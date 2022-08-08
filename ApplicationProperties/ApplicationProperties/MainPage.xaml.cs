using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ApplicationProperties
{
    public partial class MainPage : ContentPage
    {

        private readonly string _titleField = "title";
        private readonly string _notificationField = "Notifications";

        public MainPage()
        {
            InitializeComponent();

            // load data
            if (Application.Current.Properties.ContainsKey(_titleField))
                title.Text = Application.Current.Properties[_titleField].ToString();

            if (Application.Current.Properties.ContainsKey(_notificationField))
                notifications.IsToggled = (bool)Application.Current.Properties[_notificationField];
        }


        // save data on entry change
        void OnChange(object sender, EventArgs e)
        {
            Application.Current.Properties[_titleField] = title.Text;
            Application.Current.Properties[_notificationField] = notifications.IsToggled;
        }
    }
}
