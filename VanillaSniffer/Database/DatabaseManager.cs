using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace VanillaSniffer.Database
{
    class DatabaseManager
    {
        public DataTable Fetch(String query)
        {
            SQLite db = new SQLite();
            db.Connect();
            DataTable data = db.Fetch(query);
            db.Close();
            return data;
        }
        public void Execute(String query)
        {
            SQLite db = new SQLite();
            db.Connect();
            db.Execute(query);
            db.Close();
        }
    }
}
