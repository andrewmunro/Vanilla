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

        public static ItemTemplateEntry[] GenerateInventoryByIDs(int[] ids)
        {
            ItemTemplateEntry[] inventory = new ItemTemplateEntry[19];
            for (int i = 0; i < ids.Length; i++)
            {
                if (ids[i] > 0)
                {
                    ItemTemplateEntry item = GetItemByID(ids[i]);
                    switch ((InventorySlotID)item.InventoryType)
                    {
                        case InventorySlotID.Head:
                            inventory[0] = item;
                            break;
                        case InventorySlotID.Shirt:
                            inventory[3] = item;
                            break;
                        case InventorySlotID.Vest:
                        case InventorySlotID.Robe:
                            inventory[4] = item;
                            break;
                        case InventorySlotID.Waist:
                            inventory[5] = item;
                            break;
                        case InventorySlotID.Legs:
                            inventory[6] = item;
                            break;
                        case InventorySlotID.Feet:
                            inventory[7] = item;
                            break;
                        case InventorySlotID.Wrist:
                            inventory[8] = item;
                            break;
                        case InventorySlotID.Hands:
                            inventory[9] = item;
                            break;
                        case InventorySlotID.Ring:
                            inventory[10] = item;
                            break;
                        case InventorySlotID.Trinket:
                            inventory[12] = item;
                            break;
                        case InventorySlotID.Mainhand:
                        case InventorySlotID.Onehand:
                        case InventorySlotID.Twohand:
                            inventory[15] = item;
                            break;
                        case InventorySlotID.Offhand:
                        case InventorySlotID.Shield:
                        case InventorySlotID.Bow:
                            inventory[16] = item;
                            break;
                    }
                }
            }
            return inventory;
        }
    }
}
