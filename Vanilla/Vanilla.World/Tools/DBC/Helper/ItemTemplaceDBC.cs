using System;
using Vanilla.World.Game.Constants.Game.World.Item;
using Vanilla.World.Tools.DBC.Tables;

namespace Vanilla.World.Tools.DBC.Helper
{
    public class ItemTemplaceDBC : CachedDBC<ItemTemplateEntry>
    {
        public ItemTemplateEntry GetItemByName(String name)
        {
            return Find(r => r.name == name);
        }

        public ItemTemplateEntry GetItemByID(int id)
        {
            return Find(r => r.entry == id);
        }


        public ItemTemplateEntry[] GenerateInventoryByIDs(int[] ids)
        {
            ItemTemplateEntry[] inventory = new ItemTemplateEntry[19];
            for (int i = 0; i < ids.Length; i++)
            {
                if (ids[i] > 0)
                {
                    ItemTemplateEntry item = DBC.ItemTemplates.GetItemByID(ids[i]);
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
