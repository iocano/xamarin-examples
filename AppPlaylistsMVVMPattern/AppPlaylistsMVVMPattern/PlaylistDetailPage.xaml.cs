using AppPlaylistsMVVMPattern.ViewModels;
using Xamarin.Forms;

namespace AppPlaylistsMVVMPattern
{
    public partial class PlaylistDetailPage : ContentPage
    {
        public PlaylistDetailPage(PlaylistViewModel playlist)
        {
            InitializeComponent();
            title.Text = playlist.Title;
        }
    }
}