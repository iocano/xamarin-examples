using AppPlaylistsMVVMPattern.Services;
using AppPlaylistsMVVMPattern.ViewModels;
using Xamarin.Forms;

namespace AppPlaylistsMVVMPattern
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
            // BindingContext = new MainPageViewModel(new PageService());
            ViewModel = new MainPageViewModel(new PageService());
        }

        // No needed anymore, listView has been bound to vm list
        // protected override void OnAppearing() => base.OnAppearing();
        // ViewModels.LoadPlaylistsCommand.Exectue();


        void OnPlaylistSelected(object sender, SelectedItemChangedEventArgs e)
        {
            // (BindingContext as MainPageViewModel).SelectPlaylistCommand.Execute(e.SelectedItem);
            ViewModel.SelectPlaylistCommand.Execute(e.SelectedItem);
        }

        private MainPageViewModel ViewModel
        {
            get { return BindingContext as MainPageViewModel; }
            set { BindingContext = value; }
        }
    }
}
