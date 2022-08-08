using AppPlaylists.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppPlaylists
{
    public partial class MainPage : ContentPage
    {

        public ObservableCollection<Playlist> _playlist 
            = new ObservableCollection<Playlist>();

        public MainPage() => InitializeComponent(); 

        protected override void OnAppearing()
        {
            base.OnAppearing();
            playlistListview.ItemsSource = _playlist;
        }

        void OnAddPlaylist(object sender, EventArgs e)
        {
            var newPlaylist = "Playlist " + (_playlist.Count + 1);

            _playlist.Add(new Playlist { Title = newPlaylist });

            Title = $"{_playlist.Count} Playlists";
        }

        void OnPlaylistSelected (object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            var playlist = e.SelectedItem as Playlist;
            playlist.IsFavorite = !playlist.IsFavorite;

            playlistListview.SelectedItem = null;

            Navigation.PushAsync(new PlaylistDetailPage(playlist));

        }

    }
}
