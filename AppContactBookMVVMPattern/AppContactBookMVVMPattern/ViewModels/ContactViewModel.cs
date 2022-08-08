using AppContactBookMVVMPattern.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppContactBookMVVMPattern.ViewModels
{
    public class ContactViewModel : BaseViewModel
    {
        public ContactViewModel() { }

        public ContactViewModel(Contact contact)
        {
            Id = contact.Id;
            Phone = contact.Phone;
            Email = contact.Email;
            IsBlocked = contact.IsBlocked;  

            // initialize fields instead properties (avoid call PropertyChangeEvent)
            _firstName = contact.FirstName;
            _lastName = contact.LastName;
        }

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

    }
}
