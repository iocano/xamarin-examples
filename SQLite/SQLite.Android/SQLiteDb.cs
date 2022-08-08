using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Env = System.Environment;

[assembly: Dependency(typeof(SQLite.Droid.SQLiteDb))]
namespace SQLite.Droid
{
    public class SQLiteDb : ISQLiteDb
    {
        public SQLiteAsyncConnection GetConnection()
        {
            var folder = Env.SpecialFolder.MyDocuments;
            var folderOption = Env.SpecialFolderOption.Create;
            var documentsPath = Env.GetFolderPath(folder, folderOption);
            var path = Path.Combine(documentsPath, "MySQLite.db3");
            return new SQLiteAsyncConnection(path);
        }
    }
}