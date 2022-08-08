using PCLStorage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FileSystemPCLStorageLibrary
{
    public partial class MainPage : ContentPage
    {

        private string _fileName = "test.txt";
        private IFolder _folder = PCLStorage.FileSystem.Current.LocalStorage;
        public MainPage()
        {
            InitializeComponent();

        }
        private async Task WriteTextAsyn(string fileName, string content)
        {
            IFile file = await _folder.CreateFileAsync(fileName, CreationCollisionOption.OpenIfExists);
            await file.WriteAllTextAsync(content);
        }
        private async Task<string> ReadTextAsync(string fileName)
        {
            var file = await _folder.GetFileAsync(_fileName);
            return await file.ReadAllTextAsync();
        }

        protected async override void OnAppearing()
        {
            await WriteTextAsyn(_fileName, "Hello world");
            var content = await ReadTextAsync(_fileName);
            await DisplayAlert(_fileName, content, "Ok");
        }
    }
}
