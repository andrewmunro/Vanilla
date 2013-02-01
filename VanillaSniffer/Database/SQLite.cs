using System.Data;
using System.Data.SQLite;

namespace VanillaSniffer.Database
{
    public class SQLite
    {
        private SQLiteConnection handle;
        private string connectionString = "";
        public static string dbFile = "db.sqlite";  // Database file path [Relative|Absolute]
        public static string conStr = "Data Source=" + SQLite.dbFile + ";Version=3;";

        public SQLite()
        {
        }

        public SQLite(string conStr)
        {
            this.connectionString = conStr;
        }

        public void Connect()
        {
            if (this.connectionString.Length == 0)
                this.connectionString = SQLite.conStr;

            using (this.handle = new SQLiteConnection())
            {
                this.handle.ConnectionString = this.connectionString;
                this.handle.Open();
            }
        }

        public string ConnectionString
        {
            set
            {
                this.connectionString = value;
            }

            get
            {
                return this.connectionString;
            }
        }

        public DataTable Fetch(string sql)
        {
            if (this.handle.State.ToString() == "Closed")
                this.handle.Open();

            DataTable myTable = new DataTable();

            using (SQLiteDataAdapter myDataAdp = new SQLiteDataAdapter(sql, this.handle))
            {
                using (SQLiteCommandBuilder myCmdBld = new SQLiteCommandBuilder(myDataAdp))
                {
                    myDataAdp.Fill(myTable);
                }
            }
            return myTable;
        }

        public void Execute(string sql)
        {
            if (this.handle.State.ToString() == "Closed")
                this.handle.Open();

            using (SQLiteCommand com = new SQLiteCommand())
            {
                com.CommandText = sql;
                com.Connection = this.handle;

                com.ExecuteNonQuery();
            }

        }

        public void Close()
        {
            this.handle.Close();
        }

        ~SQLite()
        {
            this.handle.Close();
        }
    }
}
