using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace AppForm.Models
{
    public class Contact : INotifyPropertyChanged
    {
        private string _firstName;

        private string _lastName;

        public event PropertyChangedEventHandler PropertyChanged;

        public int Id { get; set; }

        public string FirstName 
        {
            get => _firstName;
            set
            {
                SetValue(ref _firstName, value);
                OnPropertyChanged(nameof(FullName));
            }
        }

        public string LastName
        {
            get => _lastName;
            set
            {
                SetValue(ref _lastName, value);
                OnPropertyChanged(nameof(FullName));
            }
        }
        
        public string Phone { get; set; }
        public string Email { get; set; }
        public bool IsBlocked { get; set; }

        public string FullName { get => $"{_firstName} {_lastName}"; }

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
                  => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        private bool SetValue<T>(ref T backingField, T value, [CallerMemberName] string propertyName = null)
        {
            if (!EqualityComparer<T>.Default.Equals(backingField, value))
            {
                backingField = value;
                OnPropertyChanged(propertyName);
                return true;
            }
            return false;
        }


    }
}
