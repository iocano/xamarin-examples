using Xamarin.Forms;

namespace AppPlaylistsMVVMPattern.ViewModels
{
    public class PlaylistViewModel : BaseViewModel
    {
        public string Title { get; set; }

        private bool _isFavorite;
        public bool IsFavorite
        {
            get => _isFavorite; 
            set
            {
                SetValue(ref _isFavorite, value);
                OnPropertyChanged(nameof(Color));
            }
        }

        public Color Color { get => _isFavorite ? Color.Pink : Color.Black; }
    }
}
