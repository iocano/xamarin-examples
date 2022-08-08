using AppContactBookMVVMPattern.Droid;
using AppContactBookMVVMPattern.Persistence;
using SQLite;
using System;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLiteDb))]
namespace AppContactBookMVVMPattern.Droid
{
    public class SQLiteDb : ISQLiteDb
    {
        public SQLiteAsyncConnection GetConnectionAsync()
        {
            var folder = Environment.SpecialFolder.MyDocuments;
            var folderOption = Environment.SpecialFolderOption.Create;
            var documentsPath = Environment.GetFolderPath(folder, folderOption);
            var path = Path.Combine(documentsPath, "MySQLite.db3");
            return  new SQLiteAsyncConnection(path);
        }
    }
}