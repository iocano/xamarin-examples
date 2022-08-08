using AppConsumingRestApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppConsumingRestApi
{
    public partial class MainPage : ContentPage
    {
        private const string _url = "https://www.googleapis.com/books/v1/volumes";
        private const string parameters = "?projection=lite&q={0}&startIndex={1}&maxResults={2}";
        private readonly HttpClient _client = new HttpClient();

        public readonly BindableProperty IsLoadingProperty
            = BindableProperty.Create("IsLoading", typeof(bool), typeof(MainPage));

        public bool IsLoading
        {
            get { return (bool)GetValue(IsLoadingProperty); }
            set { SetValue(IsLoadingProperty, value); }
        }

        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;
        }

        private async void SearchChanged(object sender, TextChangedEventArgs e)
        {
            if (e.OldTextValue == e.NewTextValue || e.NewTextValue.Length < 3)
            {
                bookList.ItemsSource = new ObservableCollection<Item>();
                return;
            }

            IsLoading = true;

            try
            {
                var books = await GetBooks(e.NewTextValue);
                bookList.ItemsSource = books;
                bookList.IsVisible = books.Any();
                notFound.IsVisible = !bookList.IsVisible;
            }
            catch (Exception)
            {
                await DisplayAlert("Error", "Could not retrieve any book", "Ok");
            }
            IsLoading = false;
        }

        private async Task<ObservableCollection<Item>> GetBooks(string search)
        {
            // api restriction maxResults=40
            var url = _url + string.Format(parameters, search, 0, 40);

            var jsonResponse = await _client.GetAsync(url);

            if (jsonResponse.StatusCode == HttpStatusCode.NotFound)
                return new ObservableCollection<Item>();

            var content = await jsonResponse.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<Response>(content);
            return new ObservableCollection<Item>(response.Items);
        }

        private void OnBookSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            var item = e.SelectedItem as Item;
            bookList.SelectedItem = null;

            Navigation.PushAsync(new BookDetailPage(item));
        }
    }
}
