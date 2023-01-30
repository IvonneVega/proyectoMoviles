using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace proyectoMoviles
{
    public interface Database
    {
        SQLiteAsyncConnection GetConnection();
    }
}
