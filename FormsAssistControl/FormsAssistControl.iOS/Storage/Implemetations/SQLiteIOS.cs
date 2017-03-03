using FormsAssistControl.Storage.Interface;
using System;
using SQLite;
using System.IO;
using FormsAssistControl.iOS.Storage.Implemetations;

[assembly:Xamarin.Forms.Dependency(typeof(SQLiteIOS))]
namespace FormsAssistControl.iOS.Storage.Implemetations
{
    public class SQLiteIOS : ISQLite
    {
        public SQLiteConnection GetConnection()
        {
            var sqliteFileName = "TodoSQLite.db3";
            string documentspath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libraryPath = Path.Combine(documentspath, "..", "Library"); // pasta da biblioteca
            var path = Path.Combine(libraryPath, sqliteFileName);

            var conn = new SQLite.SQLiteConnection(path);

            return conn;
        }
    }
}
