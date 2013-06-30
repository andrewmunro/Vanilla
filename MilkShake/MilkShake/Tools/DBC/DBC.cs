using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Milkshake.Communication.Incoming.Character;
using Milkshake.Tools.Config;
using Milkshake.Tools.DBC.Tables;
using Milkshake.Tools.Database.Tables;
using SQLite;

namespace Milkshake.Tools.DBC
{
    public class DBC
    {
        private static SQLiteConnection SQLite;

        public static void Boot()
        {
            SQLite = new SQLiteConnection(INI.GetValue(ConfigValues.DB, ConfigValues.DBC));
        }

        public static TableQuery<ChrRacesEntry> ChrRaces
        {
            get { return SQLite.Table<ChrRacesEntry>(); }
        }

        public static TableQuery<ChrStartingOutfitEntry> ChrStartingOutfit
        {
            get { return SQLite.Table<ChrStartingOutfitEntry>(); }
        }

        public static TableQuery<ItemTemplateEntry> ItemTemplate
        {
            get { return SQLite.Table<ItemTemplateEntry>(); }
        }

        public static TableQuery<AreaTableEntry> AreaTable
        {
            get { return SQLite.Table<AreaTableEntry>(); }
        }

        public static TableQuery<AreaTriggerEntry> AreaTriggers
        {
            get { return SQLite.Table<AreaTriggerEntry>(); }
        }

        public static TableQuery<SpellEntry> Spells
        {
            get { return SQLite.Table<SpellEntry>(); }
        }

        public static ChrStartingOutfitEntry GetCharStartingOutfitString(PCCharCreate character)
        {
            return ChrStartingOutfit.ToList().Find(r => r.Class == character.Class && r.Gender == character.Gender && r.Race == character.Race);
        }

        public static ChrStartingOutfitEntry GetCharStartingOutfitString(Character character)
        {
            return ChrStartingOutfit.ToList().Find(r => r.Class == (int)character.Class && r.Gender == (int)character.Gender && r.Race == (int)character.Race);
        }

        public static ItemTemplateEntry GetItemByName(String name)
        {
            return ItemTemplate.ToList().Find(r => r.name == name);
        }

        public static ItemTemplateEntry GetItemByID(int id)
        {
            return ItemTemplate.ToList().Find(r => r.entry == id);
        }
    }
}
