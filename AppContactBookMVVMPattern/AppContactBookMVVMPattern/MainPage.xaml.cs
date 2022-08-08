using AppContactBookMVVMPattern.Persistence;
using AppContactBookMVVMPattern.Services;
using AppContactBookMVVMPattern.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppContactBookMVVMPattern
{
    public partial class MainPage : ContentPage
    {
        public MainPageViewModel ViewModel
        {
            get => BindingContext as MainPageViewModel;
            set => BindingContext = value;
        }

        public MainPage()
        {
            InitializeComponent();
            var db = DependencyService.Get<ISQLiteDb>();
            var contactStore = new SQLiteContactStore(db);
            var pageService = new PageService();
            ViewModel = new MainPageViewModel(contactStore, pageService);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ViewModel.LoadContactsCommand.Execute(null);
        }

        void OnContactSelected(object sender, SelectedItemChangedEventArgs e)
            => ViewModel.SelectContactCommand.Execute(e.SelectedItem);
    }
}
