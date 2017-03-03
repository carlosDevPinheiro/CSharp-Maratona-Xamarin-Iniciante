using FormsAssistControl.Storage.Interface;
using SQLite;
using System.IO;
using FormsAssistControl.Droid.Storage.Implemetations;

[assembly: Xamarin.Forms.Dependency(typeof(SQLiteAndroid))]
namespace FormsAssistControl.Droid.Storage.Implemetations
{
    public class SQLiteAndroid : ISQLite
    {
        public SQLiteConnection GetConnection()
        {
            SQLitePCL.Batteries.Init();
            var sqlliteFileName = "TodoSQLite.db3";
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, sqlliteFileName);

            // criando conexao
            var conn = new SQLite.SQLiteConnection(path);

            //retorna conexao com base de dados
            return conn;
        }
    }
}