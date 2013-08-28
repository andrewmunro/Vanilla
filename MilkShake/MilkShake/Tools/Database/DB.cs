using Milkshake.Tools.Config;
using Milkshake.Tools.Database.Helpers;
using Milkshake.Tools.Database.Tables;
using SQLite;

namespace Milkshake.Tools.Database
{
	public class DB
	{
		public static SQLiteConnection Character;
		public static SQLiteConnection World;
		
		public static void Boot()
		{

			Character = new SQLiteConnection(INI.GetValue(ConfigSections.DB, ConfigValues.CHARACTER));
			//TODO these values should be removed when we have finished with the databases
			Character.CreateTable(typeof(Account));
			Character.CreateTable(typeof(Character));
			Character.CreateTable(typeof(Channel));
			Character.CreateTable(typeof(ChannelCharacter));
			Character.CreateTable(typeof(CharacterSpell));
			Character.CreateTable(typeof(CharacterActionBarButton));
			Character.CreateTable(typeof(CharacterInventory));
			Character.CreateTable(typeof(CharacterMail));

			DBAccounts.CreateAccount("Graype", "password");
			DBAccounts.CreateAccount("Andrew", "password");

			World = new SQLiteConnection(INI.GetValue(ConfigSections.DB, ConfigSections.WORLD));
			World.CreateTable(typeof(CharacterCreationSpell));
			World.CreateTable(typeof(CharacterCreationActionBarButton));
			World.CreateTable(typeof(CharacterCreationInfo));
			World.CreateTable(typeof(AreaTriggerTeleport));
		}
	} 
}
