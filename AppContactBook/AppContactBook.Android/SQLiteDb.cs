using AppContactBook.Droid;
using SQLite;
using System.IO;
using Xamarin.Forms;
using Env = System.Environment;


[assembly: Dependency(typeof(SQLiteDb))]
namespace AppContactBook.Droid
{
    public class SQLiteDb : ISQLiteDb
    {
        public SQLiteAsyncConnection GetConnection()
        {
            var folder = Env.SpecialFolder.MyDocuments;

            var folderOption = Env.SpecialFolderOption.Create;
            var documentsPath = Env.GetFolderPath (folder, folderOption);

            var path = Path.Combine(documentsPath, "MySQLite.db3");
            return new SQLiteAsyncConnection(path);
        }
    }
}