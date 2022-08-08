using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FileSystem
{
    public interface IFileSystem
    {
        Task WriteTextAsync(string fileName, string text);
        Task<string> ReadTextAsync(string fileName);
    }
}
