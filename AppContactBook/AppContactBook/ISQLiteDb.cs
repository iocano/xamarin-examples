using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppContactBook
{
    public interface ISQLiteDb
    {
        SQLiteAsyncConnection GetConnection();
    }
}
