using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ApplicationPropertiesCleaner
{
    public partial class App : Application
    {

        private const string _titleKey = "title";
        private const string _notificationKey = "notification";

        public string Title
        {
            get { return Properties.ContainsKey(_titleKey) ? Properties[_titleKey].ToString() : ""; }
            set { Properties[_titleKey] = value; }
        }

        public bool Notification
        {
            get { return Properties.ContainsKey(_notificationKey) ? (bool)Properties[_notificationKey] : false; }
            set { Properties[_notificationKey] = value; }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
