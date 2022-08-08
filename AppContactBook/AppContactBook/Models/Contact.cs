using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace AppContactBook.Models
{
    public class Contact : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public bool IsBlocked { get; set; }

        public string FullName { get { return $"{FirstName} {LastName}"; } }

        private string _firstName;

        private string _lastName;

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                if (SetValue(ref _firstName, value))
                {
                    OnPropertyChanged(nameof(FullName));
                }
            }
        }

        public string LastName
        {
            get { return _lastName; }
            set
            {
                if (SetValue(ref _lastName, value))
                {
                    OnPropertyChanged(nameof(FullName));
                }
            }
        }

        private bool SetValue<T>(ref T backingField, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingField, value))
            {
                return false;
            }

            backingField = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
