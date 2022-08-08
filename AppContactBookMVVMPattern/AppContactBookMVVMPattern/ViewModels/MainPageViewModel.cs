using AppContactBookMVVMPattern.Models;
using AppContactBookMVVMPattern.Persistence;
using AppContactBookMVVMPattern.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppContactBookMVVMPattern.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        private ContactViewModel _selectedContact;

        private readonly IPageService _pageService;

        private readonly IContactStore _contactStore;

        private bool _isDataLoaded;

        public ObservableCollection<ContactViewModel> Contacts { get; private set; }
            = new ObservableCollection<ContactViewModel>();

        public ContactViewModel SelectedContact
        {
            get { return _selectedContact; }
            set { SetValue(ref _selectedContact, value); }
        }

        public ICommand LoadContactsCommand { get; private set; }

        public ICommand AddContactCommand { get; private set; }

        public ICommand DeleteContactCommand { get; private set; }

        public ICommand SelectContactCommand { get; private set; }

        public MainPageViewModel(IContactStore contactStore, IPageService pageService)
        {
            _contactStore = contactStore;
            _pageService = pageService;

            LoadContactsCommand = new Command(async () => await LoadContacts());
            AddContactCommand = new Command(async () => await AddContact());
            SelectContactCommand = new Command<ContactViewModel>(async contact => await SelectContact(contact));
            DeleteContactCommand = new Command<ContactViewModel>(async contact => await DeleteContact(contact));
        }

        private async Task LoadContacts()
        {
            if (_isDataLoaded)
                return;

            _isDataLoaded = true;

            var contacts = await _contactStore.GetConstactsAsync();
            foreach(var contact in contacts)
            {
                Contacts.Add(new ContactViewModel(contact));
            }
        }

        private async Task AddContact()
        {
            var pageDetailVm = new ContactDetailPageViewModel(
                new ContactViewModel(), _pageService, _contactStore);

            pageDetailVm.ContactAdded += (source, contact) 
                => Contacts.Add(new ContactViewModel(contact));

            await _pageService.PushAsync(new ContactDetailPage(pageDetailVm));
        }

        private async Task SelectContact(ContactViewModel contactVm)
        {
            if (contactVm == null)
                return;

            // remove highlight from list
            SelectedContact = null;

            var detailPageVm = new ContactDetailPageViewModel(contactVm, _pageService, _contactStore)
            {
                ContactUpdated = (source, contact) =>
                {
                    contactVm.Id = contact.Id;
                    contactVm.FirstName = contact.FirstName;
                    contactVm.LastName = contact.LastName;
                    contactVm.Email = contact.Email;
                    contactVm.Phone = contact.Phone;
                    contactVm.IsBlocked = contact.IsBlocked;
                }
            };

            await _pageService.PushAsync(new ContactDetailPage(detailPageVm));

        }

        private async Task DeleteContact(ContactViewModel contactVm)
        {
            var fullName = contactVm.FullName;
            var question = $"Are you sure you want to delete {fullName}?";
            if (await _pageService.DisplayAlert("Warning", question, "Ok", "Cancel"))
            {
                Contacts.Remove(contactVm);
                var dbContact = await _contactStore.GetContactAsync(contactVm.Id);
                await _contactStore.DeleteContact(dbContact);
            }
        }
            
    }
}
