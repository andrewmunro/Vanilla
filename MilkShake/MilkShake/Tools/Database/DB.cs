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
            SQLite.CreateTable(typeof(Channel));
            SQLite.CreateTable(typeof(ChannelCharacter));
            SQLite.CreateTable(typeof(CharacterCreationSpell));
            SQLite.CreateTable(typeof(CharacterSpell));
            SQLite.CreateTable(typeof(CharacterActionBarButton));
            SQLite.CreateTable(typeof(CharacterCreationActionBarButton));
            SQLite.CreateTable(typeof(CharacterCreationInfo));

            DBAccounts.CreateAccount("Graype", "password");
			DBAccounts.CreateAccount("Andrew", "password");
        }
    }

    



    

   

  
}
