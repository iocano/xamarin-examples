using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CarouselView
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<Monkey> Monkeys { get; set; }
            = new ObservableCollection<Monkey>();
        private HttpClient _httpClient = new HttpClient();
        private const string _jsonUrl = "https://montemagno.com/monkeys.json";

        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            var monkeysJson = await _httpClient.GetStringAsync(_jsonUrl);
            Monkeys.Clear(); // every time that view is show a get request is make
            var monkeys = JsonConvert.DeserializeObject<Monkey[]>(monkeysJson);
            foreach (var monkey in monkeys)
                Monkeys.Add(monkey);
        }

    }
    public class Monkey
    {
        public string Name { get; set; }
        public string Details { get; set; }
        public string Image { get; set; }
        public int Population { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
