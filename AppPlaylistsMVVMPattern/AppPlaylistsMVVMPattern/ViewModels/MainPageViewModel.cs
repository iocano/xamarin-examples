using AppPlaylistsMVVMPattern.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppPlaylistsMVVMPattern.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {

        public ObservableCollection<PlaylistViewModel> Playlists { get; private set; }
            = new ObservableCollection<PlaylistViewModel>();

        private PlaylistViewModel _selectedPlaylist;

        public PlaylistViewModel SelectedPlaylist
        {
            get { return _selectedPlaylist; }
            set { SetValue(ref _selectedPlaylist, value); }
        }

        public ICommand AddPlaylistCommand { get; private set; }
        public ICommand SelectPlaylistCommand { get; private set; }

        private readonly IPageService _pageService;

        public MainPageViewModel(IPageService pageService)
        {
            _pageService = pageService;
            AddPlaylistCommand = new Command(AddPlaylist);
            SelectPlaylistCommand = new Command<PlaylistViewModel>(async vm => await SelectPlaylist(vm));
        }

        private void AddPlaylist()
        {
            var newPlaylist = "Playlist " + (Playlists.Count + 1);
            Playlists.Add(new PlaylistViewModel { Title = newPlaylist });
        }

        private async Task SelectPlaylist(PlaylistViewModel playlist)
        {
            if (playlist == null) return;
            playlist.IsFavorite = !playlist.IsFavorite;
            SelectedPlaylist = null;
            await _pageService.PushAsync(new PlaylistDetailPage(playlist));
        }

    }
}
