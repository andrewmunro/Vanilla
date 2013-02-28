using Milkshake.Tools.Database.Helpers;
using Milkshake.Tools.Database.Tables;
using SQLite;

namespace Milkshake.Tools.Database
{
    public class DB
    {
        public static SQLiteConnection SQLite;
        
        public static void Boot(string databaseURL = "db.db3")
        {
            SQLite = new SQLiteConnection(databaseURL);

            SQLite.CreateTable(typeof(Account));
            SQLite.CreateTable(typeof(Character));

            DBAccounts.CreateAccount("Graype", "password");
			DBAccounts.CreateAccount("Andrew", "password");
        }
    }

    



    

   

  
}
