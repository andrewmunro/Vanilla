using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace VanillaSniffer.Database
{
    public class DatabaseManager
    {
        private SQLite db;

        public DatabaseManager()
        {
            db = new SQLite();
        }

        public DataTable Fetch(String query)
        {
            db.Connect();
            DataTable data = db.Fetch(query);
            db.Close();
            return data;
        }
        public void Execute(String query)
        {
            db.Connect();
            db.Execute(query);
            db.Close();
        }
    }
}
