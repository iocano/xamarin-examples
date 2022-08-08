using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppContactBookMVVMPattern.Services
{
    public class PageService : IPageService
    {
        public Page MainPage { get => Application.Current.MainPage; }

        public async Task DisplayAlert(string title, string message, string ok)
            => await MainPage.DisplayAlert(title, message, ok);

        public Task<bool> DisplayAlert(string title, string message, string ok, string cancel)
            => MainPage.DisplayAlert(title, message, ok, cancel);

        public Task<Page> PopAsync()
            => MainPage.Navigation.PopAsync();

        public Task PushAsync(Page page)
            => MainPage.Navigation.PushAsync(page);
    }
}
