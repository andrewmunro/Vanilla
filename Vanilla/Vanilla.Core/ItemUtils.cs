using Vanilla.World.Database;

namespace Vanilla.Core
{
    using Vanilla.Core.Constants;
    using Vanilla.Core.IO;

    public class ItemUtils
    {
        public static item_template[] GenerateInventoryByIDs(int[] ids)
        {
            if (ids == null) return null;

            item_template[] inventory = new item_template[19];
            for (int i = 0; i < ids.Length; i++)
            {
                if (ids[i] > 0)
                {
                    var itemEntry = ids[i];
                    item_template item = new DatabaseUnitOfWork<WorldDatabase>().GetRepository<item_template>().SingleOrDefault(it => it.entry == itemEntry);
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
