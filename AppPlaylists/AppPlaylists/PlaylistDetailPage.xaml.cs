using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppPlaylists
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlaylistDetailPage : ContentPage
    {

        private readonly Models.Playlist _playlist;

        public PlaylistDetailPage(Models.Playlist playlist)
        {
            InitializeComponent();

            _playlist = playlist;

            title.Text = _playlist.Title;
        }
    }
}