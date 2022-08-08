using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace RESTAPIConsuming.Models
{
    public class Post : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        private string _title;
        public int Id { get; set; }
        public string Title
        {
            get => _title; 
            set => SetValue(ref _title, value);
        }

        public string Body { get; set; }

        private void SetValue<T>(ref T backingField, T value,
                        [CallerMemberName] string propertyName = null)
        {
            if (!EqualityComparer<T>.Default.Equals(backingField, value))
            {
                backingField = value;
                OnPropertyChanged(propertyName);
            }
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
