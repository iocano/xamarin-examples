using AppContactBookMVVMPattern.Models;
using AppContactBookMVVMPattern.Persistence;
using AppContactBookMVVMPattern.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppContactBookMVVMPattern.ViewModels
{
    public class ContactDetailPageViewModel
    {
        private readonly IPageService _pageService;
        private readonly IContactStore _contactStore;

        public EventHandler<Contact> ContactAdded;
        public EventHandler<Contact> ContactUpdated;

        public Contact Contact { get; set; }

        public ICommand SaveCommand { get; set; }

        public ContactDetailPageViewModel(ContactViewModel contactViewModel, IPageService pageService, IContactStore contactStore)
        {
            if (contactViewModel == null)
                throw new ArgumentNullException(nameof(contactViewModel));

            _pageService = pageService;
            _contactStore = contactStore;

            SaveCommand = new Command(async () => await Save());

            Contact = new Contact
            {
                Id = contactViewModel.Id,
                FirstName = contactViewModel.FirstName,
                LastName = contactViewModel.LastName,
                Phone = contactViewModel.Phone,
                Email = contactViewModel.Email,
                IsBlocked = contactViewModel.IsBlocked
            };
        }

        async Task Save()
        {
            if (string.IsNullOrEmpty(Contact.FirstName)
                || string.IsNullOrEmpty(Contact.LastName))
            {
                await _pageService.DisplayAlert("Error", "Please enter the name", "Ok");
                return;
            }

            if (Contact.Id == 0)
            {
                await _contactStore.AddContact(Contact);
                ContactAdded?.Invoke(this, Contact);
            }
            else
            {
                await _contactStore.UpdateContact(Contact);
                ContactUpdated?.Invoke(this, Contact);
            }

            await _pageService.PopAsync();
        }
    }
}
