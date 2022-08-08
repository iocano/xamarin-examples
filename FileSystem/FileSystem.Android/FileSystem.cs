using System;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(FileSystem.Droid.FileSystem))]
namespace FileSystem.Droid
{
    public class FileSystem : IFileSystem
    {
        private Environment.SpecialFolder _myDocuments = Environment.SpecialFolder.MyDocuments;

        public async Task<string> ReadTextAsync(string fileName)
        {

            var docsPath = Environment.GetFolderPath(_myDocuments);
            var path = Path.Combine(docsPath, fileName);
            return await File.ReadAllTextAsync(path);
        }

        public async Task WriteTextAsync(string fileName, string text)
        {
            var docsPath = Environment.GetFolderPath(_myDocuments);
            var path = Path.Combine(docsPath, fileName);
            using var writer = File.CreateText(path);
            await writer.WriteAsync(text);
        }
    }
}