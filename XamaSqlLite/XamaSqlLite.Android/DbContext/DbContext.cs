using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using XamaSqlLite.DbContext;

namespace XamaSqlLite.Droid.DbContext
{
    public class DbContext: IDBContext
    {
        public SQLiteAsyncConnection GetConnection()
        {
            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, "TestDB.db3");

            return new SQLiteAsyncConnection(path);
        }
    }
}