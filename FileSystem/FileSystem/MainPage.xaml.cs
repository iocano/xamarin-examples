using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FileSystem
{
    public partial class MainPage : ContentPage
    {
        private string _fileName = "test.txt";
        private IFileSystem _fileSystem = DependencyService.Get<IFileSystem>();
        public MainPage()
        {
            InitializeComponent();
            _fileSystem.WriteTextAsync(_fileName, "hello world");
        }

        protected async override void OnAppearing()
        {
            var text = await _fileSystem.ReadTextAsync(_fileName);
            await DisplayAlert("test.txt", text, "ok");
        }
    }
}
