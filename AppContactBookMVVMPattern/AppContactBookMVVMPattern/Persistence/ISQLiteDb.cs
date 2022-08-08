using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppContactBookMVVMPattern.Persistence
{
    public interface ISQLiteDb
    {
        SQLiteAsyncConnection GetConnectionAsync();
    }
}
