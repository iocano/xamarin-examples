using Newtonsoft.Json;
using RESTAPIConsuming.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RESTAPIConsuming
{
    public partial class MainPage : ContentPage
    {
        private const string Url = "https://jsonplaceholder.typicode.com/posts";
        private readonly HttpClient _client = new HttpClient();
        private ObservableCollection<Post> _posts;

        public MainPage() => InitializeComponent();

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var content = await _client.GetStringAsync(Url);
            var posts = JsonConvert.DeserializeObject<List<Post>>(content);
            _posts = new ObservableCollection<Post>(posts);
            postList.ItemsSource = _posts;
        }

        async void OnAdd(object sender, EventArgs e)
        {
            var post = new Post { Title = "Title " + DateTime.Now.Ticks };
            // * Need check if post is successfully added on server
            _posts.Insert(0, post);
            var content = JsonConvert.SerializeObject(post);
            await _client.PostAsync(Url, new StringContent(content));
        }

        async void OnUpdate(object sender, EventArgs e)
        {
            var post = _posts[0];
            // * Need check if post is successfully updated on server
            post.Title += " Updated";
            var content = JsonConvert.SerializeObject(post);
            await _client.PostAsync(Url + "/" + post.Id, new StringContent(content));

        }
        async void OnDelete(Object sender, EventArgs e)
        {
            var post = _posts[0];
            // * Need check if post is successfully deleted on server
            _posts.Remove(post);
            await _client.DeleteAsync(Url + "/" + post.Id);
        }

    }
}
