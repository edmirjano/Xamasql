using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace XamaSqlLite.DbContext
{
    public interface IDBContext
    {
        SQLiteAsyncConnection GetConnection();
    }
}
