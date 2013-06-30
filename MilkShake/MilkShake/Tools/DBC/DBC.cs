using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Milkshake.Communication.Incoming.Character;
using Milkshake.Game.Constants.Game.World.Item;
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

        public static List<ChrStartingOutfitEntry> ChrStartingOutfitList
        {
            get { return ChrStartingOutfit.ToList(); }
        }

        public static TableQuery<ItemTemplateEntry> ItemTemplate
        {
            get { return SQLite.Table<ItemTemplateEntry>(); }
        }

        public static List<ItemTemplateEntry> ItemTemplateListCache;

        public static List<ItemTemplateEntry> ItemTemplateList
        {
            get
            {
                if (ItemTemplateListCache == null) ItemTemplateListCache = ItemTemplate.ToList();

                return ItemTemplateListCache;
            }
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
            return ChrStartingOutfitList.Find(r => r.Class == character.Class && r.Gender == character.Gender && r.Race == character.Race);
        }

        public static ChrStartingOutfitEntry GetCharStartingOutfitString(Character character)
        {
            return ChrStartingOutfitList.Find(r => r.Class == (int)character.Class && r.Gender == (int)character.Gender && r.Race == (int)character.Race);
        }

        public static ItemTemplateEntry GetItemByName(String name)
        {
            return ItemTemplateList.Find(r => r.name == name);
        }

        public static ItemTemplateEntry GetItemByID(int id)                 
        {
            return ItemTemplateList.Find(r => r.entry == id);
        }

        public static Dictionary<InventorySlotID, ItemTemplateEntry> GenerateInventoryByIDs(int[] ids)
        {
            Dictionary<InventorySlotID, ItemTemplateEntry> output = new Dictionary<InventorySlotID, ItemTemplateEntry>();

            for (int i = 0; i < ids.Length; i++)
            {
                if (ids[i] > 0)
                {
                    ItemTemplateEntry item = GetItemByID(ids[i]);
                    if (item != null && item.InventoryType > 0) output.Add((InventorySlotID)item.InventoryType, item);
                }
            }

            return output;
        }
    }
}
