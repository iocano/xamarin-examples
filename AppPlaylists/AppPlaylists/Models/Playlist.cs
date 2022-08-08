using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace AppPlaylists.Models
{
    public class Playlist : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        public string Title { get; set; }

        private bool _isFavorite;

        public bool IsFavorite
        {
            get { return _isFavorite; }
            set
            {
                SetValue(ref _isFavorite, value);
                OnPropertyChanged(nameof(Color));
            }
        }

        public Color Color
        {
            get => _isFavorite ? Color.Pink : Color.Black; 
        }

        protected void SetValue<T>(ref T backingField, T value, [CallerMemberName] string propertyName = null)
        {
            if (!EqualityComparer<T>.Default.Equals(backingField, value))
            {
                backingField = value;
                OnPropertyChanged(propertyName);
            }
        }


        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    }
}
