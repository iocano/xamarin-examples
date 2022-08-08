using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SQLite
{
    public interface ISQLiteDb
    {
        SQLite.SQLiteAsyncConnection GetConnection();
    }
}
