using Goal.Droid;
using System;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLite_Android))]
namespace Goal.Droid
{
    public class SQLite_Android : ISQLite
    {
        public SQLite_Android()
        {

        }

        public string GetDatabasePath(string filename)
        {
            string documentPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentPath, filename);
            return path;
        }
    }
}